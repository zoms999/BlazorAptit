namespace BlazorAptit
{
    internal partial class SampleConfig
    {
        internal SampleConfig()
        {
            SampleBrowser.SampleList.Add(new SampleList
            {
                Name = "DataGrid",
                Category = "Grids",
                Directory = "Grid",
                Type = SampleType.Updated,
                Samples = DataGrid,
                ControllerName = "DataGrid",
                DemoPath = "datagrid/overview"
            });
          
            
        }
    }
}