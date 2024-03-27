using System;
using System.Collections.Generic;
using caluireMobile.models.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace caluireMobile.Models.Data;

public partial class CaluiremobileContext : DbContext
{
    public CaluiremobileContext()
    {
    }

    public CaluiremobileContext(DbContextOptions<CaluiremobileContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employe> Employes { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<PriseEnCharge> PriseEnCharges { get; set; }

    public virtual DbSet<Produit> Produits { get; set; }

    public virtual DbSet<RendezVou> RendezVous { get; set; }

    public virtual DbSet<Tchat> Tchats { get; set; }

    public virtual DbSet<Traduction> Traductions { get; set; }

    public virtual DbSet<Traiter> Traiters { get; set; }

    public virtual DbSet<Transactionpaiment> Transactionpaiments { get; set; }

    public virtual DbSet<Typesproduit> Typesproduits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;database=caluiremobile", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.Property(e => e.IdClient).HasColumnName("Id_client");
            entity.Property(e => e.Abonnee).HasColumnName("abonnee");
            entity.Property(e => e.Adresse)
                .HasMaxLength(50)
                .HasColumnName("adresse");
            entity.Property(e => e.AdresseMail)
                .HasMaxLength(50)
                .HasColumnName("adresseMail");
            entity.Property(e => e.MotDepasse).HasMaxLength(50);
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Prénom)
                .HasMaxLength(50)
                .HasColumnName("prénom");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Employe>(entity =>
        {
            entity.HasKey(e => e.IdEmploye).HasName("PRIMARY");

            entity.ToTable("employes");

            entity.Property(e => e.IdEmploye).HasColumnName("Id_employe");
            entity.Property(e => e.Adresse)
                .HasMaxLength(50)
                .HasColumnName("adresse");
            entity.Property(e => e.DateEmbauche)
                .HasColumnType("datetime")
                .HasColumnName("dateEmbauche");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .HasColumnName("mail");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .HasColumnName("prenom");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasKey(e => e.IdOperation).HasName("PRIMARY");

            entity.ToTable("operations");

            entity.Property(e => e.IdOperation).HasColumnName("Id_operation");
            entity.Property(e => e.AdressePickup)
                .HasMaxLength(50)
                .HasColumnName("adressePickup");
            entity.Property(e => e.DateDemande)
                .HasColumnType("datetime")
                .HasColumnName("dateDemande");
            entity.Property(e => e.DateRecuperation)
                .HasColumnType("datetime")
                .HasColumnName("dateRecuperation");
            entity.Property(e => e.DateReparation)
                .HasColumnType("datetime")
                .HasColumnName("dateReparation");
            entity.Property(e => e.DateRetour)
                .HasColumnType("datetime")
                .HasColumnName("dateRetour");
            entity.Property(e => e.DateVentes)
                .HasColumnType("datetime")
                .HasColumnName("dateVentes");
            entity.Property(e => e.FlagReparationPickUpVente)
                .HasMaxLength(50)
                .HasColumnName("flag_reparation_pickUp_vente_");
            entity.Property(e => e.Montant)
                .HasPrecision(10, 2)
                .HasColumnName("montant");
            entity.Property(e => e.Quantite).HasColumnName("quantite");
            entity.Property(e => e.ServiceExpress).HasColumnName("serviceExpress");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        modelBuilder.Entity<PriseEnCharge>(entity =>
        {
            entity.HasKey(e => new { e.IdEmploye, e.IdOperation })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("prise_en_charge");

            entity.HasIndex(e => e.IdOperation, "Id_operation");

            entity.Property(e => e.IdEmploye).HasColumnName("Id_employe");
            entity.Property(e => e.IdOperation).HasColumnName("Id_operation");
        });

        modelBuilder.Entity<Produit>(entity =>
        {
            entity.HasKey(e => e.IdProduit).HasName("PRIMARY");

            entity.ToTable("produits");

            entity.HasIndex(e => e.IdTypesproduit, "Id_typesProduit");

            entity.Property(e => e.IdProduit).HasColumnName("Id_produit");
            entity.Property(e => e.FlagClientEmploye)
                .HasMaxLength(50)
                .HasColumnName("flag_client_employe_");
            entity.Property(e => e.IdTypesproduit).HasColumnName("Id_typesProduit");
            entity.Property(e => e.Marque)
                .HasMaxLength(50)
                .HasColumnName("marque");
            entity.Property(e => e.NomProduit)
                .HasMaxLength(50)
                .HasColumnName("nomProduit");
            entity.Property(e => e.Photographie)
                .HasMaxLength(255)
                .HasColumnName("photographie");
            entity.Property(e => e.Prix)
                .HasPrecision(10, 2)
                .HasColumnName("prix");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<RendezVou>(entity =>
        {
            entity.HasKey(e => new { e.IdClient, e.IdOperation })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("rendez_vous");

            entity.HasIndex(e => e.IdOperation, "Id_operation");

            entity.Property(e => e.IdClient).HasColumnName("Id_client");
            entity.Property(e => e.IdOperation).HasColumnName("Id_operation");
            entity.Property(e => e.DateHeureRdv)
                .HasColumnType("datetime")
                .HasColumnName("dateHeureRdv");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Tchat>(entity =>
        {
            entity.HasKey(e => new { e.IdClient, e.IdEmploye })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("tchat");

            entity.HasIndex(e => e.IdEmploye, "Id_employe");

            entity.Property(e => e.IdClient).HasColumnName("Id_client");
            entity.Property(e => e.IdEmploye).HasColumnName("Id_employe");
            entity.Property(e => e.NomUtilisateur).HasMaxLength(50);
            entity.Property(e => e.SocketId)
                .HasMaxLength(50)
                .HasColumnName("socketId");
        });

        modelBuilder.Entity<Traduction>(entity =>
        {
            entity.HasKey(e => e.IdTraduction).HasName("PRIMARY");

            entity.ToTable("traduction");

            entity.Property(e => e.IdTraduction).HasColumnName("Id_traduction");
            entity.Property(e => e.Clef)
                .HasMaxLength(250)
                .HasColumnName("clef");
            entity.Property(e => e.Langue)
                .HasMaxLength(10)
                .HasColumnName("langue");
            entity.Property(e => e.Valeur)
                .HasColumnType("text")
                .HasColumnName("valeur");
        });

        modelBuilder.Entity<Traiter>(entity =>
        {
            entity.HasKey(e => new { e.IdOperation, e.IdProduit })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("traiter");

            entity.HasIndex(e => e.IdProduit, "Id_produit");

            entity.Property(e => e.IdOperation).HasColumnName("Id_operation");
            entity.Property(e => e.IdProduit).HasColumnName("Id_produit");
        });

        modelBuilder.Entity<Transactionpaiment>(entity =>
        {
            entity.HasKey(e => e.IdTransactionPaiment).HasName("PRIMARY");

            entity.ToTable("transactionpaiments");

            entity.HasIndex(e => e.IdOperation, "Id_operation");

            entity.Property(e => e.IdTransactionPaiment).HasColumnName("Id_transactionPaiment");
            entity.Property(e => e.DateTransaction)
                .HasColumnType("datetime")
                .HasColumnName("dateTransaction");
            entity.Property(e => e.IdOperation).HasColumnName("Id_operation");
            entity.Property(e => e.MethodePayement)
                .HasMaxLength(50)
                .HasColumnName("methodePayement");
            entity.Property(e => e.Montant)
                .HasPrecision(10, 2)
                .HasColumnName("montant");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Typesproduit>(entity =>
        {
            entity.HasKey(e => e.IdTypesProduit).HasName("PRIMARY");

            entity.ToTable("typesproduits");

            entity.Property(e => e.IdTypesProduit).HasColumnName("Id_typesProduit");
            entity.Property(e => e.NomTypes)
                .HasMaxLength(50)
                .HasColumnName("nomTypes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
