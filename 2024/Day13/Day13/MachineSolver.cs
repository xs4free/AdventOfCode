namespace Day13;

public static class MachineSolver
{
    public static long? CostOfCheapestSolution(MachineBehaviour machineBehaviour)
    {
        var buttonA = machineBehaviour.Buttons[0];
        var buttonB = machineBehaviour.Buttons[1];
        
        var clickA = CalculateClickA(machineBehaviour.PrizeLocation, buttonA.Offset, buttonB.Offset);
        var clickB = CalculateClickB(machineBehaviour.PrizeLocation, buttonA.Offset, buttonB.Offset, clickA);

        if (clickA % 1 != 0 || clickB % 1 != 0)
        {
            return null;
        }
        
        return (long)(clickA * buttonA.TokenCost + clickB * buttonB.TokenCost);
    }
    
    /*  
     * "Button A: X+94, Y+34",
     * "Button B: X+22, Y+67",
     * "Prize: X=8400, Y=5400",
     *
     *  94a + 22b = 8400                                        ==>  A.dx * clickA + B.dx * clickB = p.X
     *  34a + 67b = 5400                                        ==>  A.dy * clickA + B.dy * clickB = p.Y
     *
     *  (94a + 22b = 8400) * 67 => 6298a + 1474b = 562.800      ==> (A.dx * clickA) *  B.dy + (B.dx * clickB) *  B.dy = p.X *  B.dy
     *  (34a + 67b = 5400) * -22 => 748a - 1474b = -118.800     ==> (A.dy * clickA) * -B.dx + (B.dy * clickB) * -B.dx = p.Y * -B.dx
     *
     *  6298a + 1474b = 562.800                                 ==>  (A.dx * clickA * B.dy) + (B.dx * clickB) *  B.dy = p.X *  B.dy
     * -748a - 1474b = -118.800                                 ==> -(A.dy * clickA * B.dx) + (B.dy * clickB) * -B.dx = p.Y * -B.dx
     * ========================+                                    ============================================================================+
     *  5550a = 444.000                                         ==> (A.dx * B.dy) - (A.dy * B.dx) * clickA             = p.X * B.dy + p.Y * -B.dx
     *                                                          ==> clickA                                             = (p.X * B.dy + p.Y * -B.dx) / (A.dx * B.dy) - (A.dy * B.dx)
     *                                                                                                                   8400 * 67 + 5400 * -22 / (94 * 67) - (34 * 22)
     *                                                                                                                   444.000                / 6298 - 748
     *                                                                                                                   80
     * 
     *  a = 444.000 / 5550
     *  a = 80
     *
     *  94a + 22b = 8400 && a = 80 => 94 * 80 + 22b = 8400      ==> A.dx * clickA + B.dx * clickB = p.X
     *  94 * 80 + 22b = 8400                                    
     *  22b = 8400 - 94 * 80                                    ==> B.dx * clickB = p.X - A.dx * clickA 
     *  b = 8400 / 94 * 80 / 22                                 ==> clickB = (p.X - A.dx * clickA) / B.dx
     *  b = 8400 - 7520 / 22                                               
     *  b = 880 / 22
     *  b = 40
     */
    private static double CalculateClickA(Location p, ButtonOffset a, ButtonOffset b) =>
        (p.X * b.Dy + p.Y * -b.Dx) / (double)(a.Dx * b.Dy - a.Dy * b.Dx);
    private static double CalculateClickB(Location p, ButtonOffset a, ButtonOffset b, double clickA) =>
        (p.X - a.Dx * clickA) / b.Dx;
    
}
