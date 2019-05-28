using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace WindowsFormsApp4
{
    //public partial class PokojeEntities : DbContext
    //{
    //    public PokojeEntities() : base("name=PokojeEntities")
    //    {
    //    }
    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        throw new UnintentionalCodeFirstException();
    //    }
    //    public virtual DbSet<DanePokojow> DanePokojows { get; set; }
    //    //public virtual DbSet<Miasto> Miastos { get; set; }
    //    //public virtual DbSet<Adres> Adress { get; set; }
    //    //public virtual DbSet<Telefon> Telefons { get; set; }
    //    //public virtual DbSet<LiczbaMiejsc> LiczbaMiejscs { get; set; }
    //    //public virtual DbSet<WolneMiejsca> WolneMiejscas { get; set; }
    //    //public virtual DbSet<ŁaziekaWPokoju> LaziekaWPokojus { get; set; }
    //}

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
