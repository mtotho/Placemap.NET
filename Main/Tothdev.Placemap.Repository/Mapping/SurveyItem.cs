using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tothdev.Placemap.Repository.Mapping
{
    public class SurveyItem : EntityTypeConfiguration<Entity.SurveyItem>
    {
        public SurveyItem()
        {
            ToTable("SurveyItem");
            HasKey(e => e.Id);


            Property(x => x.MaximumValue)
                .IsOptional();

            Property(x => x.MinimumValue)
                .IsOptional();

            Property(x => x.UpdateDate)
                .IsOptional();
        }
    }
}
