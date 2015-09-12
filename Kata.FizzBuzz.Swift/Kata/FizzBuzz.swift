class FizzBuzz {
    func parse(number:Int) -> String {
        
        if number <= 0 {
            return "\(number)"
        }
        
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
    
    func parseAllNumbers(numbers: [Int]) -> [String] {
        return numbers.map(parse)
    }
}