namespace CharGenerator
{
    public class BigramWord : Generator
    {
        public BigramWord(Random rd) : base(rd) { }

        protected override void CreateItemsAndWeights()
        {
            int lines = 200;
            string path = "sourse/words.txt";

            weights = new int[lines];
            items = new string[lines];

            StreamReader reader = new StreamReader(path);

            for (int i = 0; i < lines; i++)
            {
                string line = reader.ReadLine();

                string[] splitLine = line.Split(new char[] { ' ', '\t' });

                weights[i] = Convert.ToInt32(splitLine[0]);
                items[i] = splitLine[1].ToLower();
            }
        }
    }
}
