using Microsoft.EntityFrameworkCore;
using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;
using QuanLyHocVien.Servicer;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy(MyAllowSpecificOrigins, build =>
{
  build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITaiKhoanServicer, TaiKhoanServicer>();
builder.Services.AddScoped<ITaiKhoanPhanQuyenServicer, TaiKhoanPhanQuyenServicer>();
builder.Services.AddScoped<ITaiKhoanLichHocServicer, TaiKhoanLichHocServicer>();
builder.Services.AddScoped<ITaiKhoanHocVienServicer, TaiKhoanHocVienServicer>();
builder.Services.AddScoped<IPhanQuyenServicer, PhanQuyenServicer>();
builder.Services.AddScoped<IMonHocServicer, MonHocServicer>();
builder.Services.AddScoped<ILichHocServicer,LichHocServicer>();
builder.Services.AddScoped<IKhoaHocServicer, KhoaHocServicer>();
builder.Services.AddScoped<IKhoaHocMonHocServicer, KhoaHocMonHocServicer>();
builder.Services.AddScoped<IKhoaHocLichHocServicer, KhoaHocLichHocServicer>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
