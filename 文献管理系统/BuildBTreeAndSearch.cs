using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

public class Consts
{
    public const int M = 100;                  // B树的最小度数
    public const int KeyMax = 2 * M - 1;     // 节点包含关键字的最大个数
    public const int KeyMin = M - 1;         // 非根节点包含关键字的最小个数
    public const int ChildMax = KeyMax + 1;  // 孩子节点的最大个数
    public const int ChildMin = KeyMin + 1;  // 孩子节点的最小个数
}

public class Statics
{
    public static int nowIndex = 1;
    public static StreamWriter authorBTreeSW = null;
}

public class BTreeNode
{
    private bool leaf;
    public KeyValuePair<string, List<string>>[] keys;
    public int keyNumber;
    public BTreeNode[] children;
    public int nodeIndex;
    public int nodeRows;


    public BTreeNode(bool leaf)
    {
        this.leaf = leaf;
        keys = new KeyValuePair<string, List<string>>[Consts.KeyMax];
        children = new BTreeNode[Consts.ChildMax];
    }

    /// <summary>在未满的节点中插入键值</summary>
    /// <param name="key">键值</param>
    public void InsertNonFull(KeyValuePair<string, List<string>> key)
    {
        var index = keyNumber - 1;

        if (leaf == true)
        {
            // 找到合适位置,并且移动节点键值腾出位置
            while (index >= 0 && String.Compare(keys[index].Key, key.Key) == 1)
            {
                keys[index + 1] = keys[index];
                index--;
            }

            // 在index后边新增键值
            keys[index + 1] = key;
            keyNumber = keyNumber + 1;
        }
        else
        {
            // 找到合适的子孩子索引
            while (index >= 0 && String.Compare(keys[index].Key, key.Key) == 1) index--;

            // 如果孩子节点已满
            if (children[index + 1].keyNumber == Consts.KeyMax)
            {
                // 分裂该孩子节点
                SplitChild(index + 1, children[index + 1]);

                // 分裂后中间节点上跳父节点
                // 孩子节点已经分裂成2个节点,找到合适的一个
                if (String.Compare(keys[index + 1].Key, key.Key) == -1) index++;
            }

            // 插入键值
            children[index + 1].InsertNonFull(key);
        }
    }

    /// <summary>分裂节点</summary>
    /// <param name="childIndex">孩子节点索引</param>
    /// <param name="waitSplitNode">待分裂节点</param>
    public void SplitChild(int childIndex, BTreeNode waitSplitNode)
    {
        var newNode = new BTreeNode(waitSplitNode.leaf);
        newNode.keyNumber = Consts.KeyMin;

        // 把待分裂的节点中的一般节点搬到新节点
        for (var j = 0; j < Consts.KeyMin; j++)
        {
            newNode.keys[j] = waitSplitNode.keys[j + Consts.ChildMin];

            // 清0
            waitSplitNode.keys[j + Consts.ChildMin] = new KeyValuePair<string, List<string>>(null, null);
        }

        // 如果待分裂节点不是叶子节点
        if (waitSplitNode.leaf == false)
        {
            for (var j = 0; j < Consts.ChildMin; j++)
            {
                // 把孩子节点也搬过去
                newNode.children[j] = waitSplitNode.children[j + Consts.ChildMin];

                // 清0
                waitSplitNode.children[j + Consts.ChildMin] = null;
            }
        }

        waitSplitNode.keyNumber = Consts.KeyMin;

        // 拷贝一般键值到新节点
        for (var j = keyNumber; j >= childIndex + 1; j--)
            children[j + 1] = children[j];

        children[childIndex + 1] = newNode;
        for (var j = keyNumber - 1; j >= childIndex; j--)
            keys[j + 1] = keys[j];

        // 把中间键值上跳至父节点
        keys[childIndex] = waitSplitNode.keys[Consts.KeyMin];

        // 清0
        waitSplitNode.keys[Consts.KeyMin] = new KeyValuePair<string, List<string>>(null, null);

        // 根节点键值数自加
        keyNumber = keyNumber + 1;
    }

    /// <summary>根据节点索引顺序打印节点键值</summary>
    public void PrintByKey()
    {
        int index;
        Console.WriteLine(keyNumber.ToString());
        for (index = 0; index < keyNumber; index++)
        {
            // 如果不是叶子节点, 先打印叶子子节点. 
            if (leaf == false) children[index].PrintByKey();

            Console.WriteLine(keys[index].Key);
        }

        // 打印孩子节点
        if (leaf == false) children[index].PrintByKey();
    }

    public void InitialNodeIndex()
    {
        nodeIndex = Statics.nowIndex;
        nodeRows++;
        for (int i = 0; i < keyNumber; i++)
        {
            nodeRows = nodeRows + keys[i].Value.Count + 1;
        }
        if (leaf)
        {
            nodeRows++;
        }
        else
        {
            nodeRows = nodeRows + keyNumber + 1;
        }
        Statics.nowIndex += nodeRows;
        if (leaf)
            return;
        for (int i = 0; i <= keyNumber; i++)
        {
            children[i].InitialNodeIndex();
        }
    }

    public void SaveNode()
    {
        Statics.authorBTreeSW.Write(nodeRows.ToString() + "/" + keyNumber.ToString() + "/" + (leaf ? "1" : "0") + "\n");
        for (int i = 0; i < keyNumber; i++)
        {
            Statics.authorBTreeSW.Write(keys[i].Key + "/" + keys[i].Value.Count.ToString() + "\n");
            for (int j = 0; j < keys[i].Value.Count; j++)
            {
                Statics.authorBTreeSW.Write(keys[i].Value[j] + "\n");
            }
        }

        if (leaf)
        {
            Statics.authorBTreeSW.Write("noChild\n");
        }
        else
        {
            for (int i = 0; i <= keyNumber; i++)
            {
                Statics.authorBTreeSW.Write(children[i].nodeIndex.ToString() + "\n");
            }
        }

        if (leaf)
            return;
        for (int i = 0; i <= keyNumber; i++)
        {
            children[i].SaveNode();
        }
    }

    /// <summary>查找某键值是否已经存在树中</summary>
    /// <param name="key">键值</param>
    /// <returns></returns>
    public BTreeNode Find(string key)
    {
        int index = 0;
        while (index < keyNumber && String.Compare(key, keys[index].Key) == 1) index++;

        // 该key已经存在, 返回该索引位置节点
        if (String.Compare(keys[index].Key, key) == 0) return this;

        // key 不存在,并且节点是叶子节点
        if (leaf == true) return null;

        // 递归在孩子节点中查找
        return children[index].Find(key);
    }
}

public class BTree
{
    public BTreeNode Root { get; private set; }

    public BTree() { }

    /// <summary>根据节点索引顺序打印节点键值</summary>
    public void PrintByKey()
    {
        if (Root == null)
        {
            Console.WriteLine("空树");
            return;
        }

        Root.PrintByKey();
    }

    public void InitialNodeIndex()
    {
        if (Root == null)
        {
            Console.WriteLine("空树");
            return;
        }
        Statics.nowIndex = 1;
        Root.InitialNodeIndex();
    }

    public void SaveBTree(string filePath)
    {
        if (Root == null)
        {
            Console.WriteLine("空树");
            return;
        }
        Statics.authorBTreeSW = new StreamWriter(new FileStream(filePath, FileMode.Append, FileAccess.Write));
        Root.SaveNode();
        Statics.authorBTreeSW.Close();
    }

    /// <summary>查找某键值是否已经存在树中</summary>
    /// <param name="key">键值</param>
    /// <returns></returns>
    public BTreeNode Find(string key)
    {
        if (Root == null) return null;

        return Root.Find(key);
    }

    /// <summary>新增B树节点键值</summary>
    /// <param name="key">键值</param>
    public void Insert(KeyValuePair<string, List<string>> key)
    {
        if (Root == null)
        {
            Root = new BTreeNode(true);
            Root.keys[0] = key;
            Root.keyNumber = 1;
            return;
        }

        if (Root.keyNumber == Consts.KeyMax)
        {
            var newNode = new BTreeNode(false);

            newNode.children[0] = Root;
            newNode.SplitChild(0, Root);

            var index = 0;
            if (String.Compare(newNode.keys[0].Key, key.Key) == -1) index++;

            newNode.children[index].InsertNonFull(key);
            Root = newNode;
        }
        else
        {
            Root.InsertNonFull(key);
        }
    }
}

public class MinHeap
{
    public KeyValuePair<string, int>[] heap;
    public int count;
    public int max;
    public MinHeap(int max)
    {
        this.max = max;
        heap = new KeyValuePair<string, int>[max];
        for (int i = 0; i < max; i++)
        {
            heap[i] = new KeyValuePair<string, int>("", 0);
        }
        count = 0;
    }
    public void insert(KeyValuePair<string, int> kvp)
    {
        if (count < max)
        {
            heap[count] = kvp;
            siftUp(count);
            count++;
        }
        else
        {
            if (kvp.Value > heap[0].Value)
            {
                heap[0] = kvp;
                siftDown(0);
            }
        }
    }

    public void siftUp(int index)
    {
        while (index > 0)
        {
            if (heap[(index - 1) / 2].Value > heap[index].Value)
            {
                KeyValuePair<string, int> temp = heap[(index - 1) / 2];
                heap[(index - 1) / 2] = heap[index];
                heap[index] = temp;
                index = (index - 1) / 2;
            }
            else
            {
                break;
            }
        }
    }

    public void siftDown(int index)
    {
        bool flag = true;
        while (flag)
        {
            if (2 * index + 2 < count)
            {
                if (heap[2 * index + 1].Value < heap[2 * index + 2].Value)
                {
                    if (heap[index].Value > heap[2 * index + 1].Value)
                    {
                        KeyValuePair<string, int> temp = heap[2 * index + 1];
                        heap[2 * index + 1] = heap[index];
                        heap[index] = temp;
                        index = 2 * index + 1;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (heap[index].Value > heap[2 * index + 2].Value)
                    {
                        KeyValuePair<string, int> temp = heap[2 * index + 2];
                        heap[2 * index + 2] = heap[index];
                        heap[index] = temp;
                        index = 2 * index + 2;
                    }
                    else
                    {
                        break;
                    }
                }

            }
            else if (2 * index + 2 == count)
            {
                if (heap[index].Value > heap[2 * index + 1].Value)
                {
                    KeyValuePair<string, int> temp = heap[2 * index + 1];
                    heap[2 * index + 1] = heap[index];
                    heap[index] = temp;
                }
                break;
            }
            else
            {
                break;
            }
        }

    }

}
class PreprocessingUtils
{
    public Dictionary<string, List<string>> authorIndexDic;
    public Dictionary<string, List<string>> keywordIndexDic;
    public Dictionary<string, Dictionary<string, int>> yearKeywordDic;

    public delegate void ListenerHandler();
    public event ListenerHandler Listener = null;
    /// <summary>
    /// 文件格式化
    /// </summary>

    public void fileFormatting(string filePath, string outputPath)
    {
        FileStream fs_in = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs_in);
        FileStream fs_out = new FileStream(outputPath, FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs_out);
        int i = 99;
        StringBuilder temp;
        string line;
        sw.Write("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n");
        sr.ReadLine();
        sr.ReadLine();
        sw.Write("<!DOCTYPE doctypeName [\n" +
            "<!ENTITY nbsp \"&#160;\">\n" +
            "<!ENTITY iexcl \"&#161;\">\n" +
            "<!ENTITY cent \"&#162;\">\n" +
            "<!ENTITY pound \"&#163;\">\n" +
            "<!ENTITY curren \"&#164;\">\n" +
            "<!ENTITY yen \"&#165;\">\n" +
            "<!ENTITY brvbar \"&#166;\">\n" +
            "<!ENTITY sect \"&#167;\">\n" +
            "<!ENTITY uml \"&#168;\">\n" +
            "<!ENTITY copy \"&#169;\">\n" +
            "<!ENTITY ordf \"&#170;\">\n" +
            "<!ENTITY laquo \"&#171;\">\n" +
            "<!ENTITY not \"&#172;\">\n" +
            "<!ENTITY shy \"&#173;\">\n" +
            "<!ENTITY reg \"&#174;\">\n" +
            "<!ENTITY macr \"&#175;\">\n" +
            "<!ENTITY deg \"&#176;\">\n" +
            "<!ENTITY plusmn \"&#177;\">\n" +
            "<!ENTITY sup2 \"&#178;\">\n" +
            "<!ENTITY sup3 \"&#179;\">\n" +
            "<!ENTITY acute \"&#180;\">\n" +
            "<!ENTITY micro \"&#181;\">\n" +
            "<!ENTITY para \"&#182;\">\n" +
            "<!ENTITY middot \"&#183;\">\n" +
            "<!ENTITY cedil \"&#184;\">\n" +
            "<!ENTITY sup1 \"&#185;\">\n" +
            "<!ENTITY ordm \"&#186;\">\n" +
            "<!ENTITY raquo \"&#187;\">\n" +
            "<!ENTITY frac14 \"&#188;\">\n" +
            "<!ENTITY frac12 \"&#189;\">\n" +
            "<!ENTITY frac34 \"&#190;\">\n" +
            "<!ENTITY iquest \"&#191;\">\n" +
            "<!ENTITY times \"&#215;\">\n" +
            "<!ENTITY divide \"&#247;\">\n" +
            "<!ENTITY Agrave \"&#192;\">\n" +
            "<!ENTITY Aacute \"&#193;\">\n" +
            "<!ENTITY Acirc \"&#194;\">\n" +
            "<!ENTITY Atilde \"&#195;\">\n" +
            "<!ENTITY Auml \"&#196;\">\n" +
            "<!ENTITY Aring \"&#197;\">\n" +
            "<!ENTITY AElig \"&#198;\">\n" +
            "<!ENTITY Ccedil \"&#199;\">\n" +
            "<!ENTITY Egrave \"&#200;\">\n" +
            "<!ENTITY Eacute \"&#201;\">\n" +
            "<!ENTITY Ecirc \"&#202;\">\n" +
            "<!ENTITY Euml \"&#203;\">\n" +
            "<!ENTITY Igrave \"&#204;\">\n" +
            "<!ENTITY Iacute \"&#205;\">\n" +
            "<!ENTITY Icirc \"&#206;\">\n" +
            "<!ENTITY Iuml \"&#207;\">\n" +
            "<!ENTITY ETH \"&#208;\">\n" +
            "<!ENTITY Ntilde \"&#209;\">\n" +
            "<!ENTITY Ograve \"&#210;\">\n" +
            "<!ENTITY Oacute \"&#211;\">\n" +
            "<!ENTITY Ocirc \"&#212;\">\n" +
            "<!ENTITY Otilde \"&#213;\">\n" +
            "<!ENTITY Ouml \"&#214;\">\n" +
            "<!ENTITY Oslash \"&#216;\">\n" +
            "<!ENTITY Ugrave \"&#217;\">\n" +
            "<!ENTITY Uacute \"&#218;\">\n" +
            "<!ENTITY Ucirc \"&#219;\">\n" +
            "<!ENTITY Uuml \"&#220;\">\n" +
            "<!ENTITY Yacute \"&#221;\">\n" +
            "<!ENTITY THORN \"&#222;\">\n" +
            "<!ENTITY szlig \"&#223;\">\n" +
            "<!ENTITY agrave \"&#224;\">\n" +
            "<!ENTITY aacute \"&#225;\">\n" +
            "<!ENTITY acirc \"&#226;\">\n" +
            "<!ENTITY atilde \"&#227;\">\n" +
            "<!ENTITY auml \"&#228;\">\n" +
            "<!ENTITY aring \"&#229;\">\n" +
            "<!ENTITY aelig \"&#230;\">\n" +
            "<!ENTITY ccedil \"&#231;\">\n" +
            "<!ENTITY egrave \"&#232;\">\n" +
            "<!ENTITY eacute \"&#233;\">\n" +
            "<!ENTITY ecirc \"&#234;\">\n" +
            "<!ENTITY euml \"&#235;\">\n" +
            "<!ENTITY igrave \"&#236;\">\n" +
            "<!ENTITY iacute \"&#237;\">\n" +
            "<!ENTITY icirc \"&#238;\">\n" +
            "<!ENTITY iuml \"&#239;\">\n" +
            "<!ENTITY eth \"&#240;\">\n" +
            "<!ENTITY ntilde \"&#241;\">\n" +
            "<!ENTITY ograve \"&#242;\">\n" +
            "<!ENTITY oacute \"&#243;\">\n" +
            "<!ENTITY ocirc \"&#244;\">\n" +
            "<!ENTITY otilde \"&#245;\">\n" +
            "<!ENTITY ouml \"&#246;\">\n" +
            "<!ENTITY oslash \"&#248;\">\n" +
            "<!ENTITY ugrave \"&#249;\">\n" +
            "<!ENTITY uacute \"&#250;\">\n" +
            "<!ENTITY ucirc \"&#251;\">\n" +
            "<!ENTITY uuml \"&#252;\">\n" +
            "<!ENTITY yacute \"&#253;\">\n" +
            "<!ENTITY thorn \"&#254;\">\n" +
            "<!ENTITY yuml \"&#255;\">\n]>\n");

        do
        {

            line = sr.ReadLine();
            if (line == "\n" || line == "") continue;
            if (line == null) break;
            temp = new StringBuilder(line);
            i++;
            temp.Replace(@"<article", "<article index=\"" + i.ToString() + "\"");
            temp.Replace(@"<book ", "<book index=\"" + i.ToString() + "\" ");
            temp.Replace(@"<www", "<www index=\"" + i.ToString() + "\"");
            temp.Replace(@"<inproceedings", "<inproceedings index=\"" + i.ToString() + "\"");
            temp.Replace(@"<phdthesis", "<phdthesis index=\"" + i.ToString() + "\"");
            temp.Replace(@"<incollection", "<incollection index=\"" + i.ToString() + "\"");

            temp.Replace(@"<sub>", "");
            temp.Replace(@"</sub>", "");
            temp.Replace(@"<sup>", "");
            temp.Replace(@"</sup>", "");
            temp.Replace(@"<i>", "");
            temp.Replace(@"</i>", "");
            temp.Replace(@"<tt>", "");
            temp.Replace(@"</tt>", "");
            sw.WriteLine(temp);
            if (i % 1000000 == 0)
            {
                if (Listener != null)//确定事件已被订阅，也就是已被注册
                {
                    Listener();//触发事件
                }
            }
        } while (true);

        Console.WriteLine("读取成功");
        sw.Close();
        Console.WriteLine("存储成功");
        Console.WriteLine();
    }
    /// <summary>
    /// 获取作者和关键字字典
    /// </summary>
    

    /// <summary>
    /// 获取作者和关键字字典_改进版
    /// </summary>
    public void getAuthorAndKeyword(string filePath)
    {
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.DtdProcessing = DtdProcessing.Parse;

        XmlReader reader = XmlReader.Create(filePath, settings);
        reader.MoveToContent();
        string index = "";
        int flag = 0;
        authorIndexDic = new Dictionary<string, List<string>>();
        keywordIndexDic = new Dictionary<string, List<string>>();
        yearKeywordDic = new Dictionary<string, Dictionary<string, int>>();
        string[] ignore = { "for", "and", "on", "the", "a", "of", "with", "an", "in", "at", "have", "is", "are", 
            "has", "not", "by", "into", "through", "off", "out", "from", "to" };
        string[] keywordArr = null;
        while (reader.Read())
        {
            flag++;

            if (flag % 1000000 == 0)
            {
                Console.WriteLine(flag.ToString());
                if (Listener != null)//确定事件已被订阅，也就是已被注册
                {
                    Listener();//触发事件
                }
            }

            if (reader.NodeType == XmlNodeType.Element)
            {
                if (reader.AttributeCount > 0)
                {
                    if (reader.GetAttribute("index") != "" && reader.GetAttribute("index") != null)
                        index = reader.GetAttribute("index");
                }
                if (reader.Name == "author")
                {

                    string authorName = reader.ReadElementContentAsString();
                    if (authorIndexDic.ContainsKey(authorName))
                    {
                        authorIndexDic[authorName].Add(index);
                    }
                    else
                    {
                        authorIndexDic.Add(authorName, new List<string>());
                        authorIndexDic[authorName].Add(index);
                    }

                }
                else if (reader.Name == "title")
                {

                    string title = reader.ReadElementContentAsString().ToLower();
                    if (title == "home page")
                        continue;
                    keywordArr = title.Split(' ', '-', '_', ':', '\'', '(', ')', '.', ',', '+', '\\', '/', '?', '!', '"',
                        '*', '|', '<', '>', '@', ';', '&', '*', '^', '†', '$', '=', '™', '²', '{', '}', '[', ']', '#', 
                        '%', '°', '∘', '«', '®', 'ℝ', '″', '»', '~');
                    foreach (string s in keywordArr)
                    {
                        if (s != "" && !((System.Collections.IList)ignore).Contains(s))
                        {
                            if (keywordIndexDic.ContainsKey(s))
                            {
                                keywordIndexDic[s].Add(index);
                            }
                            else
                            {
                                keywordIndexDic.Add(s, new List<string>());
                                keywordIndexDic[s].Add(index);
                            }
                        }
                    }
                }
                else if (reader.Name == "year")
                {
                    string year = reader.ReadElementContentAsString().ToLower();
                    if (yearKeywordDic.ContainsKey(year))
                    {
                        foreach (string s in keywordArr)
                        {
                            if (s != "" && !((System.Collections.IList)ignore).Contains(s))
                            {
                                if (yearKeywordDic[year].ContainsKey(s))
                                {
                                    yearKeywordDic[year][s]++;
                                }
                                else
                                {
                                    yearKeywordDic[year].Add(s, 1);
                                }
                            }
                        }
                    }
                    else
                    {
                        yearKeywordDic.Add(year, new Dictionary<string, int>());
                        foreach (string s in keywordArr)
                        {
                            if (s != "" && !((System.Collections.IList)ignore).Contains(s))
                            {
                                if (yearKeywordDic[year].ContainsKey(s))
                                {
                                    yearKeywordDic[year][s]++;
                                }
                                else
                                {
                                    yearKeywordDic[year].Add(s, 1);
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine("finish author dictionary");
        Console.WriteLine("finish keyword dictionary");
    }
    /// <summary>
    /// 查找每一年的热点词汇
    /// </summary>
    /// <param name="filePath"></param>
    public void findHotspotTop10(string outputPath)
    {
        FileStream fs_out = new FileStream(outputPath, FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs_out);
        for (int i = 1900; i < 2022; i++)
        {
            if (yearKeywordDic.ContainsKey(i.ToString()))
            {
                MinHeap yearHeap = new MinHeap(10);
                KeyValuePair<string, int>[] result = new KeyValuePair<string, int>[10];
                foreach (KeyValuePair<string, int> kvp in yearKeywordDic[i.ToString()])
                {
                    yearHeap.insert(kvp);
                }
                for (int j = 9; j >= 0; j--)
                {
                    result[j] = yearHeap.heap[0];
                    yearHeap.count--;
                    yearHeap.heap[0] = yearHeap.heap[yearHeap.count];
                    yearHeap.siftDown(0);
                }
                sw.Write(i.ToString() + "\n");
                for (int j = 0; j < 10; j++)
                {
                    sw.Write(result[j].Key + "/" + result[j].Value.ToString() + "\n");
                }
            }
        }
        sw.Close();
        Console.WriteLine("finish hotspot top10 index");
    }

    /// <summary>
    /// 建立前100名作者索引
    /// </summary>
    /// <param name="filePath"></param>
    public void findTop100(string filePath)
    {
        FileStream fs_out = new FileStream(filePath, FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs_out);
        MinHeap resultHeap = new MinHeap(100);
        KeyValuePair<string, int>[] result = new KeyValuePair<string, int>[100];
        //Console.WriteLine(result.Count);
        foreach (KeyValuePair<string, List<string>> kvp in authorIndexDic)
        {
            resultHeap.insert(new KeyValuePair<string, int>(kvp.Key, kvp.Value.Count));
        }
        for (int i = 99; i >= 0; i--)
        {
            result[i] = resultHeap.heap[0];
            resultHeap.count--;
            resultHeap.heap[0] = resultHeap.heap[resultHeap.count];
            resultHeap.siftDown(0);
        }
        for (int i = 0; i < 100; i++)
        {
            sw.Write(result[i].Key + "/" + result[i].Value.ToString() + "\n");
        }
        sw.Close();
        Console.WriteLine("finish top100 index");
    }
    /// <summary>
    /// 创建作者b树索引
    /// </summary>
    public void createAuthorBTree(string output_Author_Path)
    {
        var bTree = new BTree();
        int i = 0;
        foreach (KeyValuePair<string, List<string>> kvp in authorIndexDic)
        {
            bTree.Insert(kvp);
            i++;
            //if (i > 40)
            //    break;
            if (i % 10000 == 0)
            {
                Console.WriteLine(i.ToString());
                if (Listener != null)//确定事件已被订阅，也就是已被注册
                {
                    Listener();//触发事件
                }
            }
        }
        Console.WriteLine("finish create Btree");
        //bTree.PrintByKey();
        bTree.InitialNodeIndex();
        Console.WriteLine("finish Btree nodeIndex");
        bTree.SaveBTree(output_Author_Path);
        Console.WriteLine("finish save Btree");
    }
    /// <summary>
    /// 创建关键字b树索引
    /// </summary>
    public void createKeywordBTree(string output_keyword_path)
    {
        var bTree = new BTree();
        int i = 0;
        foreach (KeyValuePair<string, List<string>> kvp in keywordIndexDic)
        {
            bTree.Insert(kvp);
            i++;
            //if (i > 40)
            //    break;
            if (i % 10000 == 0)
                Console.WriteLine(i.ToString());
        }
        Console.WriteLine("finish create Btree");
        //bTree.PrintByKey();
        bTree.InitialNodeIndex();
        Console.WriteLine("finish Btree nodeIndex");
        bTree.SaveBTree(output_keyword_path);
        Console.WriteLine("finish save Btree");
    }
}

class Search
{
    public string[] authorBTreeLines;
    public string[] keywordBTreeLines;
    public void InitialAuthorBTreeLines(string filePath)
    {
        authorBTreeLines = File.ReadAllLines(filePath);
    }
    public void DeleteAuthorBTreeLines()
    {
        authorBTreeLines = null;
    }
    public string[] SearchAuthor(string key, int line)
    {
        int startLine = line;
        string[] temp1 = authorBTreeLines[line].Split('/');
        int nodeRows = int.Parse(temp1[0]);
        int keyNumber = int.Parse(temp1[1]);
        bool isLeaf = (temp1[2] == "1" ? true : false);
        line++;
        for (int i = 0; i < keyNumber; i++)
        {
            string[] temp2 = authorBTreeLines[line].Split('/');
            string authorName = temp2[0];
            int articleNum = int.Parse(temp2[1]);
            if (key == authorName)
            {
                string[] result = new string[articleNum];
                for (int j = 0; j < articleNum; j++)
                {
                    result[j] = authorBTreeLines[line + j + 1];
                }
                return result;
            }
            else if (String.Compare(key, authorName) == -1)
            {
                if (isLeaf)
                {
                    return null;
                }
                else
                {
                    return SearchAuthor(key, int.Parse(authorBTreeLines[startLine + nodeRows - keyNumber - 1 + i]) - 1);
                }
            }
            else
            {
                line = line + articleNum + 1;
            }
        }
        if (isLeaf)
        {
            return null;
        }
        else
        {
            return SearchAuthor(key, int.Parse(authorBTreeLines[startLine + nodeRows - 1]) - 1);
        }

    }
    public void InitialKeywordBTreeLines(string filePath)
    {
        keywordBTreeLines = File.ReadAllLines(filePath);
    }
    public void DeleteKeywordBTreeLines()
    {
        keywordBTreeLines = null;
    }
    public string[] SearchKeyword(string key, int line)
    {
        int startLine = line;
        string[] temp1 = keywordBTreeLines[line].Split('/');
        int nodeRows = int.Parse(temp1[0]);
        int keyNumber = int.Parse(temp1[1]);
        bool isLeaf = (temp1[2] == "1" ? true : false);
        line++;
        for (int i = 0; i < keyNumber; i++)
        {
            string[] temp2 = keywordBTreeLines[line].Split('/');
            string authorName = temp2[0];
            int articleNum = int.Parse(temp2[1]);
            if (key == authorName)
            {
                string[] result = new string[articleNum];
                for (int j = 0; j < articleNum; j++)
                {
                    result[j] = keywordBTreeLines[line + j + 1];
                }
                return result;
            }
            else if (String.Compare(key, authorName) == -1)
            {
                if (isLeaf)
                {
                    return null;
                }
                else
                {
                    return SearchKeyword(key, int.Parse(keywordBTreeLines[startLine + nodeRows - keyNumber - 1 + i]) - 1);
                }
            }
            else
            {
                line = line + articleNum + 1;
            }
        }
        if (isLeaf)
        {
            return null;
        }
        else
        {
            return SearchKeyword(key, int.Parse(keywordBTreeLines[startLine + nodeRows - 1]) - 1);
        }

    }
   
    public string[] SearchTitle(string title)
    {

        string[] keywords = title.ToLower().Split(' ', '-', '_', ':', '\'', '(', ')', '.', ',', '+', '\\', '/', '?', '!', '"', '*', '|', '<', '>', '@', ';', '&', '*', '^', '†', '$', '=', '™', '²', '{', '}', '[', ']', '#', '%', '°', '∘', '«', '®', 'ℝ', '″', '»', '~');
        string[] ignore = { "for", "and", "on", "the", "a", "of", "with", "an", "in", "at", "have", "is", "are", "has", "not", "by", "into", "through", "off", "out", "from", "to" };
        if (keywords.Length == 0)
            return null;
        string[] returnList = SearchKeyword(keywords[0], 0);
        if(returnList==null)
        {
            return null;
        }
        List<string> result =returnList.ToList<string>();
        if (result == null)
            return null;
        for (int i = 1; i < keywords.Length; i++)
        {
            if (keywords[i] != "" && !((System.Collections.IList)ignore).Contains(keywords[i]))
            {
                List<string> temp = SearchKeyword(keywords[i], 0).ToList<string>();
                if (temp == null)
                    return null;
                result = result.Intersect(temp).ToList();
            }
        }
        if (result != null)
        {
            return result.ToArray<string>();
        }
        else
            return null;
        
    }
}

