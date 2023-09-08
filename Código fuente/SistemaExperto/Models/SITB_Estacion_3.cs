namespace SistemaExperto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class SITB_Estacion_3
    {
        [Key]
        public int Est3_Id { get; set; }
        public string Est_Id { get; set; }
        public string Est3_Fecha { get; set; }
        public Nullable<decimal> A0_Solar_radiation_avg { get; set; }
        public Nullable<decimal> A1_Solar_Panel_last { get; set; }
        public Nullable<decimal> A2_Precipitation_sum { get; set; }
        public Nullable<decimal> A3_Wind_speed_avg { get; set; }
        public Nullable<decimal> A3_Wind_speed_max { get; set; }
        public Nullable<decimal> A4_Battery_last { get; set; }
        public Nullable<decimal> A5_HC_Serial_Number_last { get; set; }
        public Nullable<decimal> A6_HC_Air_temperature_avg { get; set; }
        public Nullable<decimal> A6_HC_Air_temperature_max { get; set; }
        public Nullable<decimal> A6_HC_Air_temperature_min { get; set; }
        public Nullable<decimal> A7_HC_Relative_humidity_avg { get; set; }
        public Nullable<decimal> A7_HC_Relative_humidity_max { get; set; }
        public Nullable<decimal> A7_HC_Relative_humidity_min { get; set; }
        public Nullable<decimal> A8_Dew_Point_avg { get; set; }
        public Nullable<decimal> A8_Dew_Point_min { get; set; }
        public Nullable<decimal> A9_Latitude_last { get; set; }
        public Nullable<decimal> A10_Longitude_last { get; set; }
        public Nullable<decimal> A11_Altitude_last { get; set; }
        public Nullable<decimal> A12_Horizontal_dilusion_of_position_last { get; set; }
        public Nullable<decimal> A13_VPD_avg { get; set; }
        public Nullable<decimal> A13_VPD_min { get; set; }
        public Nullable<decimal> A14_Wind_speed_max_max { get; set; }
        public Nullable<decimal> A15_DeltaT_avg { get; set; }
        public Nullable<decimal> A15_DeltaT_max { get; set; }
        public Nullable<decimal> A15_DeltaT_min { get; set; }
        public Nullable<decimal> A16_Sensor_board_battery_last { get; set; }
        public Nullable<decimal> A17_Input_number_last { get; set; }
        public Nullable<decimal> A18_Soil_media_last { get; set; }
        public Nullable<decimal> A19_PI54a__VWC__avg { get; set; }
        public Nullable<decimal> A20_Input_number_last { get; set; }
        public Nullable<decimal> A21_Soil_media_last { get; set; }
        public Nullable<decimal> A22_PI54a__VWC__avg { get; set; }
        public Nullable<decimal> A23_Input_number_last { get; set; }
        public Nullable<decimal> E3_Evapotrans { get; set; }

    }
}