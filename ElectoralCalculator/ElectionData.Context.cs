﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElectoralCalculator
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    internal partial class ElectionDataContainer : DbContext
    {
        public ElectionDataContainer()
            : base("name=ElectionDataContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Person> PersonSet { get; set; }
        public DbSet<Candidate> CandidateSet { get; set; }
        public DbSet<Vote> VoteSet { get; set; }
    }
}