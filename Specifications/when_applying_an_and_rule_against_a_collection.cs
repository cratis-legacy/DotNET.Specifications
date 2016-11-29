using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;

namespace Cratis.Specifications.Specifications
{
    [Subject(typeof(Specification<>))]
    public class when_applying_an_and_rule_against_a_collection : given.rules_and_colored_shapes
    {
        static IEnumerable<ColoredShape> satisfied_shapes;
        static IEnumerable<ColoredShape> the_greens;
        static IEnumerable<ColoredShape> the_squares;
        static IEnumerable<ColoredShape> green_squares;

        Establish context = () =>
        {
            the_greens = my_colored_shapes.Where(s => s.Color == "Green").AsEnumerable();
            the_squares = my_colored_shapes.Where(s => s.Shape == "Square").AsEnumerable();

            green_squares = the_greens.Intersect(the_squares).Distinct();

        };

        Because of = () => satisfied_shapes = squares.And(green).SatisfyingElementsFrom(my_colored_shapes);

        It should_have_all_instances_satisfying_both_parts = () => satisfied_shapes.ShouldContainOnly(green_squares);
    }
}