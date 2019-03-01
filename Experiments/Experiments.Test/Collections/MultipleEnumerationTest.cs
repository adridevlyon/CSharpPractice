using System.Collections.Generic;
using System.Linq;
using Experiments.Collections;
using FluentAssertions;
using Xunit;

namespace Experiments.Test.Collections
{
    public class MultipleEnumerationTest
    {
        private readonly List<RecursiveElement> _recursiveList;

        public MultipleEnumerationTest()
        {
            _recursiveList = new List<RecursiveElement>
            {
                new RecursiveElement
                {
                    Id = 1,
                    SubElementIds = new List<int> { 2, 3 }
                },
                new RecursiveElement
                {
                    Id = 2,
                    SubElementIds = new List<int> { 3, 4 }
                },
                new RecursiveElement
                {
                    Id = 3,
                    SubElementIds = new List<int> { 5 }
                },
                new RecursiveElement
                {
                    Id = 4,
                    SubElementIds = new List<int>()
                },
                new RecursiveElement
                {
                    Id = 5,
                    SubElementIds = new List<int> { 6, 7 }
                },
                new RecursiveElement
                {
                    Id = 6,
                    SubElementIds = new List<int>()
                },
                new RecursiveElement
                {
                    Id = 7,
                    SubElementIds = new List<int>()
                }
            };
        }

        [Fact]
        public void Given_RecursiveElements_When_GoingThroughNestedEnumerations_Then_ThereIsNoException()
        {
            var allDescendantsByElement = _recursiveList.ToDictionary(e => e, e => e.GetAllDescendants(_recursiveList));

            allDescendantsByElement.Should().NotBeNull();
            allDescendantsByElement.Should().HaveCount(_recursiveList.Count);
            allDescendantsByElement.Should().ContainKeys(_recursiveList);

            allDescendantsByElement[_recursiveList[0]].Should().HaveCount(6);
            allDescendantsByElement[_recursiveList[0]].Should().ContainInOrder(_recursiveList[1], _recursiveList[2],
                _recursiveList[3], _recursiveList[4], _recursiveList[5], _recursiveList[6]);

            allDescendantsByElement[_recursiveList[1]].Should().HaveCount(5);
            allDescendantsByElement[_recursiveList[1]].Should().ContainInOrder(_recursiveList[2],
                _recursiveList[3], _recursiveList[4], _recursiveList[5], _recursiveList[6]);

            allDescendantsByElement[_recursiveList[2]].Should().HaveCount(3);
            allDescendantsByElement[_recursiveList[2]].Should().ContainInOrder(_recursiveList[4], _recursiveList[5], _recursiveList[6]);

            allDescendantsByElement[_recursiveList[3]].Should().BeEmpty();

            allDescendantsByElement[_recursiveList[4]].Should().HaveCount(2);
            allDescendantsByElement[_recursiveList[4]].Should().ContainInOrder(_recursiveList[5], _recursiveList[6]);

            allDescendantsByElement[_recursiveList[5]].Should().BeEmpty();

            allDescendantsByElement[_recursiveList[6]].Should().BeEmpty();
        }

        [Fact]
        public void Given_RecursiveElements_When_ChangingAPropertyThroughNestedEnumerations_Then_ThereIsNoException()
        {
            _recursiveList.ForEach(e => e.SetAllDescendants(_recursiveList));

            _recursiveList[0].AllDescendants.Should().HaveCount(6);
            _recursiveList[0].AllDescendants.Should().ContainInOrder(_recursiveList[1], _recursiveList[2],
                _recursiveList[3], _recursiveList[4], _recursiveList[5], _recursiveList[6]);

            _recursiveList[1].AllDescendants.Should().HaveCount(5);
            _recursiveList[1].AllDescendants.Should().ContainInOrder(_recursiveList[2],
                _recursiveList[3], _recursiveList[4], _recursiveList[5], _recursiveList[6]);

            _recursiveList[2].AllDescendants.Should().HaveCount(3);
            _recursiveList[2].AllDescendants.Should().ContainInOrder(_recursiveList[4], _recursiveList[5], _recursiveList[6]);

            _recursiveList[3].AllDescendants.Should().BeEmpty();

            _recursiveList[4].AllDescendants.Should().HaveCount(2);
            _recursiveList[4].AllDescendants.Should().ContainInOrder(_recursiveList[5], _recursiveList[6]);

            _recursiveList[5].AllDescendants.Should().BeEmpty();

            _recursiveList[6].AllDescendants.Should().BeEmpty();
        }
    }
}
