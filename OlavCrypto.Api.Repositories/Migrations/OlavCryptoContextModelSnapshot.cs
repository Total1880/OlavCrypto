﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OlavCrypto.Api.Repositories;

namespace OlavCrypto.Api.Repositories.Migrations
{
    [DbContext(typeof(OlavCryptoContext))]
    partial class OlavCryptoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OlavCrypto.Models.Cryptocurrency", b =>
                {
                    b.Property<int>("CryptocurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("PriceUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CryptocurrencyId");

                    b.ToTable("CryptocurrencyList");
                });

            modelBuilder.Entity("OlavCrypto.Models.CryptocurrencyDetails", b =>
                {
                    b.Property<int>("CryptocurrencyDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<double>("BalanceInUSD")
                        .HasColumnType("float");

                    b.Property<int?>("CryptocurrencyWalletId")
                        .HasColumnType("int");

                    b.HasKey("CryptocurrencyDetailsId");

                    b.HasIndex("CryptocurrencyWalletId");

                    b.ToTable("CryptocurrencyDetailsList");
                });

            modelBuilder.Entity("OlavCrypto.Models.CryptocurrencyWallet", b =>
                {
                    b.Property<int>("CryptocurrencyWalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CryptocurrencyId")
                        .HasColumnType("int");

                    b.Property<int?>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("CryptocurrencyWalletId");

                    b.HasIndex("CryptocurrencyId");

                    b.HasIndex("WalletId");

                    b.ToTable("CryptocurrencyWalletList");
                });

            modelBuilder.Entity("OlavCrypto.Models.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BalanceInUSD")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WalletId");

                    b.ToTable("WalletList");
                });

            modelBuilder.Entity("OlavCrypto.Models.CryptocurrencyDetails", b =>
                {
                    b.HasOne("OlavCrypto.Models.CryptocurrencyWallet", "CryptocurrencyWallet")
                        .WithMany()
                        .HasForeignKey("CryptocurrencyWalletId");

                    b.Navigation("CryptocurrencyWallet");
                });

            modelBuilder.Entity("OlavCrypto.Models.CryptocurrencyWallet", b =>
                {
                    b.HasOne("OlavCrypto.Models.Cryptocurrency", "Cryptocurrency")
                        .WithMany()
                        .HasForeignKey("CryptocurrencyId");

                    b.HasOne("OlavCrypto.Models.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId");

                    b.Navigation("Cryptocurrency");

                    b.Navigation("Wallet");
                });
#pragma warning restore 612, 618
        }
    }
}
