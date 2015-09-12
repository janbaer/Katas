import XCTest

class Kata: XCTestCase {
    var fizzBuzz: FizzBuzz!

    override func setUp() {
        self.fizzBuzz = FizzBuzz()

    }


    func test_shouldReturn_Fizz() {
        XCTAssertEqual("Fizz", self.fizzBuzz.parse(3))
    }

    func test_shouldReturn_WhenNumberIs6ItShouldReturn_Fizz() {
        XCTAssertEqual("Fizz", self.fizzBuzz.parse(6))
    }

    func test_shouldReturn_Buzz() {
        XCTAssertEqual("Buzz", self.fizzBuzz.parse(5))
    }

    func test_WhenNumberIs10ItshouldReturn_Buzz() {
        XCTAssertEqual("Buzz", self.fizzBuzz.parse(10))
    }


    func test_shouldReturn_FizzBuzzFor15 (){
        XCTAssertEqual("FizzBuzz", self.fizzBuzz.parse(15))
    }

    func test_shouldReturn_aNumber() {
        XCTAssertEqual("1", self.fizzBuzz.parse(1))
    }

    func test_shouldReturn_Zero() {
        XCTAssertEqual("0", self.fizzBuzz.parse(0))
    }

    func test_WhenWeHaveAListOfNumbersItShouldReturnTheExpectedArrayOfString() {
        let numbers = Array<Int>(1...15)
        let expectedString: [String] = ["1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"]

        let result = self.fizzBuzz.parseAllNumbers(numbers)

        XCTAssertEqual(expectedString, result)
    }

}
