namespace General.DataAccess.Business
{
    public class PagerModel<T> where T : class
    {
        public Pager Pager { get; set; }
        public IEnumerable<T> DataList { get; set; }
    }
}
