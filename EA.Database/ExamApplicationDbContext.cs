using EA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Database

{
    public class ExamApplicationDbContext : DbContext
    {
        public ExamApplicationDbContext(DbContextOptions<ExamApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<EnrollmentModel> Enrollments { get; set; }
        public DbSet<OtpIdentityVerification> OtpIdentityVerifications { get; set; }
        public DbSet<BasicDetails>  BasicDetails { get; set; }
        public DbSet<EducationalDetails> EducationalDetails { get; set;}
    }
}
