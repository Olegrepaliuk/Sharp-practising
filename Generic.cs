class Program
    {
        static void Main(string[] args)
        {
            List<Document> dc = new List<Document>();
            var t1 = Document.CreateDocument();
            dc.Add(t1);
            Console.WriteLine(t1);
            Console.ReadKey();
        }

        public static T Max<T>(T[] source) where T: IComparable
        {
            if (source.Length == 0)
            {
                return default(T);
            }
            else
            {
                Array.Sort(source);
                return source[source.Length - 1];
            }
        }
        private static IEnumerable<int> ZipSum(IEnumerable<int> first, IEnumerable<int> second)
        {
            var e1 = first.GetEnumerator();
            var e2 = second.GetEnumerator();
            while(e1.MoveNext()&e2.MoveNext)
            {
                yield return e1.Current + e2.Current;
            }
        }
    }
    public class Document
    {
        public int Num { get; set; }
        public string Name { get; set; }
        public List<int> SomeNumbers { get; set; }
        public static Document CreateDocument()
        {
            return new Document { Num = 9, Name = "Test" };
        }

        public override string ToString()
        {
            return string.Format("Good document {0}, with number {1}", Name, Num);
        }
    }