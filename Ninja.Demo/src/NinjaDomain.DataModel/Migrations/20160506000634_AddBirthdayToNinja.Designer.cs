using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using NinjaDomain.DataModel;

namespace NinjaDomain.DataModel.Migrations
{
    [DbContext(typeof(NinjaContext))]
    [Migration("20160506000634_AddBirthdayToNinja")]
    partial class AddBirthdayToNinja
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NinjaDomain.Classes.Clan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClanName");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("NinjaDomain.Classes.Ninja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClanId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Name");

                    b.Property<bool>("ServedInOniwaban");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("NinjaDomain.Classes.NinjaEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("NinjaId");

                    b.Property<int>("Type");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("NinjaDomain.Classes.Ninja", b =>
                {
                    b.HasOne("NinjaDomain.Classes.Clan")
                        .WithMany()
                        .HasForeignKey("ClanId");
                });

            modelBuilder.Entity("NinjaDomain.Classes.NinjaEquipment", b =>
                {
                    b.HasOne("NinjaDomain.Classes.Ninja")
                        .WithMany()
                        .HasForeignKey("NinjaId");
                });
        }
    }
}
