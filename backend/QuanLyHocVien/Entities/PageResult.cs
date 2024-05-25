namespace QuanLyHocVien.Entities
{
  public class PageResult<T>
  {
    public Pagination Pagination { get; set; }
    public IEnumerable<T> Data { get; set; }

    public static IEnumerable<T> PageToResult(Pagination pagination, IEnumerable<T> t)
    {
      if (pagination.PageSize < 1 || pagination.PageNumber < 1)
      {
        pagination.PageSize = pagination.TotalCount;
        pagination.PageNumber = 1;
        return t;
      }
      else
      {
        t = t.Skip(pagination.PageSize * (pagination.PageNumber - 1)).Take(pagination.PageSize).AsQueryable();
        return t;
      }
    }

    public PageResult(Pagination pagination, IEnumerable<T> values)
    {
      Pagination = pagination;
      Data = values;
    }
  }
}
