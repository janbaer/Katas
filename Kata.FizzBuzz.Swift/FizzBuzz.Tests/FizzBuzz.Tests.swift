import XCTest

class FizzBuzz {
    func check(number: Int) -> String {
      switch (number % 3, number % 5) {
      case (0, 0):
        return "FizzBuzz"
      case (0, _):
        return "Fizz"
      case (_, 0):
        return "Buzz"
      default:
        return "\(number)"
      }
    }
}

class FizzBuzz_Tests: XCTestCase {
    var fizzBuzz: FizzBuzz!
    
    override func setUp() {
        super.setUp()

        self.fizzBuzz = FizzBuzz();
        
    }
    
    override func tearDown() {
        // Put teardown code here. This method is called after the invocation of each test method in the class.
        super.tearDown()
    }
    
    func test_When_a_number_is_dividible_through_3_it_should_return_fizz() {
        XCTAssertEqual(self.fizzBuzz.check(3), "Fizz", "Should return Fizz")
    }

    func test_When_a_number_is_dividible_through_5_it_should_return_fizz() {
        XCTAssertEqual(self.fizzBuzz.check(5), "Buzz", "Should return Buzz")
    }

    func test_When_a_number_is_dividible_through_3_and_5_it_should_return_fizzbuzz() {
        XCTAssertEqual(self.fizzBuzz.check(15), "FizzBuzz", "Should return FizzBuzz")
    }
    
    
    func test_When_a_number_is_not_dividible_through_5_or3_it_should_return_the_number_as_string() {
        XCTAssertEqual(self.fizzBuzz.check(4), "4", "Should return 4")
    }

}
