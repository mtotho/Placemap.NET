using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tothdev.Placemap.Repository.Mapping
{
    public class SurveyItemType : EntityTypeConfiguration<Entity.SurveyItemType>
    {
        public SurveyItemType()
        {
            ToTable("SurveyItemType");
            HasKey(e => e.Id);

            Property(x => x.UpdateDate)
                .IsOptional();
        }
    }
}
