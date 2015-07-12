namespace BootstrapTagHelpers.Grid {
    public class Md5TagHelper:SizedColTagHelper {

        protected override int Size => 5;
        protected override string Type => "md";
    }
}