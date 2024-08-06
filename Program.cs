using Microsoft.EntityFrameworkCore;
using TesteEscolaMVC.Data;
using TesteEscolaMVC.Repositories;
using TesteEscolaMVC.Repositories.Interfaces;
using TesteEscolaMVC.Services;
using TesteEscolaMVC.Services.Interfaces;

namespace TesteEscolaMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
            builder.Services.AddScoped<IAlunoService, AlunoService>();
            builder.Services.AddScoped<ICursoService, CursoService>();
            builder.Services.AddScoped<INotaService, NotaService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}


/* Desenvolver uma aplicação web responsável por simular ações básicas de uma escola:
1.	Cadastrar aluno (nome, sobrenome e série)
2.	Cadastrar curso (nome)
3.	Lançar uma nota por curso;
4.	Relatório com alunos por curso e notas

Regras gerais:
a)	Deve fazer uso do .Net Core;
b)	Pode fazer uso do blazor ou razor;
c)	A aplicação deverá gravar e obter os dados utilizando o Entity;
d)	A aplicação será executada pelo candidato no dia da entrevista e este deverá explicar o código fonte implementado. */