using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Builder_Pattern
{
    public class FurnitureItem
    {
        public string Name;
        public double Price;
        public double Height;
        public double Width;
        public double Weight;

        public FurnitureItem(string productName, double price, double height, double width, double weight)
        {
            this.Name = productName;
            this.Price = price;
            this.Height = height;
            this.Width = width;
            this.Weight = weight;
        }
    }
    /// <summary>
    /// The PRODUCT class
    /// </summary>
    public class InventoryReport
    {
        public string TitleSection;
        public string DimensionsSection;
        public string LogisticsSection;

        public string Debug()
        {
            return new StringBuilder()
                .AppendLine(TitleSection)
                .AppendLine(DimensionsSection)
                .AppendLine(LogisticsSection)
                .ToString();
        }
    }
    /// <summary>
    /// THe BUILDER
    /// </summary>
    public interface IFurnitureInventoryBuilder
    {
        void AddTitle();
        void AddDimensions();
        void AddLogistics(DateTime dateTime);
    }
    /// <summary>
    /// The CONCRETE CLASS
    /// </summary>
    public class DailyReportBuilder : IFurnitureInventoryBuilder
    {
        private InventoryReport _report;
        private IEnumerable<FurnitureItem> _items;


        public DailyReportBuilder(IEnumerable<FurnitureItem> items)
        {
            Reset();
            _items = items;
        }
       
        public void AddDimensions()
        {
            _report.DimensionsSection = string.Join(Environment.NewLine, _items
                .Select(p => $"Product:{p.Name} \nPrice {p.Price} \n" +
                $"Height: {p.Height} x Width: {p.Width} -> Weight {p.Weight} \n"));
        }

        public void AddLogistics(DateTime dateTime)
        {
            _report.LogisticsSection = $"Report on {dateTime}";
        }

        public void AddTitle()
        {
            _report.TitleSection = "---Daily Inventory Report--\n\n";
        }

        public InventoryReport GetDailyReport()
        {
            InventoryReport finishedReport = _report;
            Reset();
            return finishedReport;
        }

        public void Reset()
        {
            _report = new InventoryReport();
        }

    }
    /// <summary>
    /// The DIRECTOR
    /// </summary>
    public class InventoryBuildDirector
    {
        private IFurnitureInventoryBuilder _builder;

        public InventoryBuildDirector(IFurnitureInventoryBuilder concreteBuilder)
        {
            _builder = concreteBuilder;
        }

        public void BuildCompleteReport()
        {
            _builder.AddTitle();
            _builder.AddDimensions();
            _builder.AddLogistics(DateTime.Now);
        }

    }

}
