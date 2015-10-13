class Calculator():
    @staticmethod
    def splitToNumbers(input):
        numbers = []
        number = ""

        for c in input:
            if c.isdigit():
                number += c
            elif c == "-":
              number += c
            elif len(number) > 0:
                numbers.append(int(number))
                number = ""

        if len(number) > 0:
          numbers.append(int(number))

        return numbers

    @staticmethod
    def verifyNumberRanges(numbers):

      for number in numbers:
          if number < 0:
            raise ValueError('Negative Numbers are not allowed')

      return [number for number in numbers if number <= 1000]

    @staticmethod
    def calc(input):
        if len(input) == 0:
            return 0

        numbers = Calculator.splitToNumbers(input)

        numbers = Calculator.verifyNumberRanges(numbers)

        return sum(numbers)