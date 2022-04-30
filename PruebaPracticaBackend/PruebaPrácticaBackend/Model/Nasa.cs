using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPrácticaBackend.Model
{
    public class Nasa
    {
        public Links Links { get; set; }
        public int Element_count { get; set; }
        public Dictionary<string, List<Object>> Near_earth_objects { get; set; }
    }

    public class Links
    {
        public string Next { get; set; }
        public string Prev { get; set; }
        public string Self { get; set; }
    }

    public class Object
    {
        public LinksObject Links { get; set; }
        public string Id { get; set; }
        public string Neo_reference_id { get; set; }
        public string Name { get; set; }
        public string Nasa_jpl_url { get; set; }
        public double Absolute_magnitude_h { get; set; }
        public Estimated_diameter Estimated_diameter { get; set; }
        public bool Is_potentially_hazardous_asteroid { get; set; }
        public List<Close_approach_data> Close_approach_data { get; set; }
        public bool Is_sentry_object { get; set; }
    }

    public class LinksObject
    {
        public string Self { get; set; }
    }

    public class Estimated_diameter
    {
        public Distance Kilometers { get; set; }
        public Distance Meters { get; set; }
        public Distance Miles { get; set; }
        public Distance Feet { get; set; }
    }

    public class Distance
    {
        public decimal Estimated_diameter_min { get; set; }
        public decimal Estimated_diameter_max { get; set; }
    }

    public class Close_approach_data
    {
        public DateTime Close_approach_date { get; set; }
        public DateTime Close_approach_date_full { get; set; }
        public Int64 Epoch_date_close_approach { get; set; }
        public Relative_velocity Relative_velocity { get; set; }
        public Miss_distance Miss_distance { get; set; }
        public string Orbiting_body { get; set; }
    }

    public class Relative_velocity
    {
        public decimal Kilometers_per_second { get; set; }
        public decimal Kilometers_per_hour { get; set; }
        public decimal Miles_per_hour { get; set; }
    }

    public class Miss_distance
    {
        public decimal Astronomical { get; set; }
        public decimal Lunar { get; set; }
        public decimal Kilometers { get; set; }
        public decimal Miles { get; set; }
    }
}
