using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers
{
    public struct Point2D
    {
     public int X { get; set; }
     public int Y { get; set; }
    }
    [ApiController]
    [Route("[controller]")]

    public class PointsController : ControllerBase
    {
        [HttpGet("checkCollinearity")]
        public IActionResult CheckCollinearity(Point2D point1, Point2D point2, Point2D point3)
        { 
        bool areCllinear = IsCollinear(point1,point2,point3);
        return Ok (new {IsCollinear = areCllinear});
        }
        private bool IsCollinear (Point2D point1 , Point2D point2, Point2D point3)
        {
            int Slope1 = (point2.Y - point1.Y) * (point3.X - point2.X);
            int Slope2 = (point3.Y - point2.Y) * (point2.X - point1.X);
            return Slope1 == Slope2;
        }
    }
}