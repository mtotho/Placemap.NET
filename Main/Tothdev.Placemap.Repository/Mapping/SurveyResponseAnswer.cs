using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tothdev.Placemap.Repository.Mapping
{
    public class SurveyResponseAnswer : EntityTypeConfiguration<Entity.SurveyResponseAnswer>
    {
        public SurveyResponseAnswer()
        {
            ToTable("SurveyResponseAnswer");
            HasKey(e => e.Id);


            Property(x => x.UpdateDate)
                .IsOptional();
        }
    }
}
