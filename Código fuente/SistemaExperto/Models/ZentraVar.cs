namespace SistemaExperto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class ZentraVar
    {
        [Key]
        public int Id { get; set; }
        public string Datetime { get; set; }
        public string AirTemperature { get; set; }
        public string AtmosphericPressure { get; set; }
        public string BatteryPercent { get; set; }
        public string BatteryVoltage { get; set; }
        public string GustSpeed { get; set; }
        public string LightningActivity { get; set; }
        public string LightningDistance { get; set; }
        public string LoggerTemperature { get; set; }
        public string MaxPrecipRate { get; set; }
        public string Precipitation { get; set; }
        public string RHSensorTemp { get; set; }
        public string ReferencePressure { get; set; }
        public string SolarRadiation { get; set; }
        public string VPD { get; set; }
        public string VaporPressure { get; set; }
        public string WindDirection { get; set; }
        public string WindSpeed { get; set; }
        public string XaxisLevel { get; set; }
        public string YaxisLevel { get; set; }
        public string SensorOutput { get; set; }
    }
}