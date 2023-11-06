namespace Mmu.CleanBlazor.Presentation2.Areas.Playground.BindingFun.TwoWay
{
    public partial class TwoWayBinding
    {
        private string _stringValue;

        public int? NumberValue { get; set; }
        public string StringValue
        {
            get
            {
                return _stringValue;
            }
            set
            {
                if(int.TryParse(value, out var res)){
                    NumberValue = res;
                }

                _stringValue = value;
                
            }
        }
    }
}