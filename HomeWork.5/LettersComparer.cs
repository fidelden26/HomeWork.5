namespace HomeWork._5
{
    public class LettersComparer: IComparer<IGrouping<char, char>>
    {
        public int Compare(IGrouping<char, char>? x, IGrouping<char, char>? y)
        {
            if (x is null)
                throw new ArgumentNullException(nameof(x));

            if (y is null)
                throw new ArgumentNullException(nameof(y));

            if (x.Count() == y.Count()) 
            {
                if (x.Key == y.Key)
                    return 0;
                else if (x.Key < y.Key)
                    return 1;
                else
                    return -1;
            }
            else if (x.Count() > y.Count())
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }



    }
}