
namespace RoutingExample
{
    public class CustomMinLengthRouteConstraint : IRouteConstraint
    {
        private readonly int _minLength;

        public CustomMinLengthRouteConstraint(int minLength)
        {
            _minLength = minLength;
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var value) && value != null)
            {
                var stringValue = Convert.ToString(value);
                if (!string.IsNullOrEmpty(stringValue) && stringValue.Length >= _minLength)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
