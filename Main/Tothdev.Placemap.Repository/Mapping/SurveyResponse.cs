using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tothdev.Placemap.Repository.Mapping
{
    public class SurveyResponse : EntityTypeConfiguration<Entity.SurveyResponse>
    {
        public SurveyResponse()
        {
            ToTable("SurveyResponse");
            HasKey(e => e.Id);

            Property(x => x.Latitude).HasPrecision(13, 10);
            Property(x => x.Longitude).HasPrecision(13, 10);

            Property(x => x.UpdateDate)
                .IsOptional();
        }
    }
}
