using Microsoft.EntityFrameworkCore;

namespace ProjectEFWeb.Models;
public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    //Fluent API crea los mnodelos apartir de funciones
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Creamos una coleccion de categorias para poblar las tablas

        List<Categoria> categoriaInit = new List<Categoria>();
        categoriaInit.Add(new Categoria 
        {
            CategoriaId = Guid.Parse("636ab663-4d46-4b0d-99c7-17396bd1ba01"),
            Nombre = "Actividaes pendientes",
            Peso = 20
        });
        categoriaInit.Add(new Categoria
        {
            CategoriaId = Guid.Parse("636ab663-4d46-4b0d-99c7-17396bd1ba02"),
            Nombre = "Actividaes personales",
            Peso = 50
        });

        //Crea la tabla Categoria
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);

            categoria.HasData(categoriaInit);//LLamamos la coleccion que creamos arriba e instertamos en las tablas

        });


        //Creamos una coleccion de tareas para poblar las tablas
        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea 
        {
            TareaId = Guid.Parse("636ab663-4d46-4b0d-99c7-17396bd1ba10"),
            CategoriaId = Guid.Parse("636ab663-4d46-4b0d-99c7-17396bd1ba01"),
            PrioridadTarea = Prioridad.Media,
            Titulo = "Pago servicios publicos",
            FechaCreacion = DateTime.Now,
            Puntos = 5
        });

        tareasInit.Add(new Tarea
        {
            TareaId = Guid.Parse("636ab663-4d46-4b0d-99c7-17396bd1ba11"),
            CategoriaId = Guid.Parse("636ab663-4d46-4b0d-99c7-17396bd1ba02"),
            PrioridadTarea = Prioridad.Baja,
            Titulo = "Terminar de ver pelicula",
            FechaCreacion = DateTime.Now,
            Puntos = 2
          
        });

        //Crea la tabla Tarea
        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);

            tarea.HasOne(p => p.Categoria)
                 .WithMany(p => p.Tareas)
                 .HasForeignKey(p => p.CategoriaId);


            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Property(p => p.Puntos);
            tarea.Ignore(p => p.Resumen); //No crea la própiedad en la BD

            tarea.HasData(tareasInit);//LLamamos la coleccion que creamos arriba e instertamos en las tablas

        });

    }
}

