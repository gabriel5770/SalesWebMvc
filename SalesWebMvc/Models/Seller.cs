using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models

{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Double baseSalary { get; set; }
        public DateTime birthDate { get; set; }
        public Departament departament { get; set; }
        public ICollection<SalesRecord> sales { get; set; } = new List<SalesRecord>();
    
    public Seller()
        {
        }

        public Seller(int id, string name, string email, double baseSalary, DateTime birthDate, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            this.baseSalary = baseSalary;
            this.birthDate = birthDate;
            this.departament = departament;
        }

        public void AddSales(SalesRecord sr)
        {
            sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr)
        {
            sales.Remove(sr);
        }

        public double TotalSales(DateTime initial , DateTime final)
        {
            return sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);

        }
    }
}
