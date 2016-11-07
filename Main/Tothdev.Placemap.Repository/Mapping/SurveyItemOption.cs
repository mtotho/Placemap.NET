using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tothdev.Placemap.Repository.Mapping
{
    public class SurveyItemOption : EntityTypeConfiguration<Entity.SurveyItemOption>
    {
        public SurveyItemOption()
        {
            ToTable("SurveyItemOption");
            HasKey(e => e.Id);

            Property(x => x.UpdateDate)
                .IsOptional();
        }
    }
}
