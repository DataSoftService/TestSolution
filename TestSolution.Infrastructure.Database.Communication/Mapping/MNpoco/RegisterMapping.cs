using System;
using System.Collections.Generic;
using System.Text;
using TestSolution.Domain.Models;

namespace TestSolution.Infrastructure.Database.Communication.Mapping.MNpoco
{
    public class RegisterMapping : NPoco.FluentMappings.Map<Register>
    {
        public RegisterMapping()
        {
            TableName("\"Test\".Register");
            PrimaryKey("Id");
            Columns(c =>
            {
                c.Column(p => p.address).WithDbType<string>();
                c.Column(p => p.age).WithDbType<int>();
                c.Column(p => p.birth_date).WithDbType<DateTime>();
                c.Column(p => p.first_name).WithDbType<string>();
                c.Column(p => p.gender).WithDbType<string>();
                c.Column(p => p.last_name).WithDbType<string>();
                c.Column(p => p.phone).WithDbType<string>();

            });
        }
    }
}
