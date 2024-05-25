namespace QuanLyHocVien.Entities
{
  public class Pagination
  {
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages
    {
      get
      {
        if(TotalCount > 0)
        {
          int count = TotalCount / PageSize;
          if (TotalCount % PageSize == 0)
          {
            return count;
          }
          else
          {
            return count + 1;
          }
        }
        else
        {
          return 0;
        }
      }
    }
  }
}
