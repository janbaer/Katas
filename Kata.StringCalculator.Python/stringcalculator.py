import re

regex = re.compile("//(.)\\n(.+)", re.MULTILINE)

def _normalizeDelimiters(input, delimiter):
    return input.replace("\n", delimiter)

def _determinateDelimiter(input):
    delimiter = ","
    match = regex.search(input)

    if match:
        delimiter, input = match.groups()

    return delimiter, input

def _verifyNumberRanges(numbers):
    if any(number < 0 for number in numbers):
        raise ValueError('Number must be greater zero')

    return [number for number in numbers if number <= 1000]

def add(input):
    if len(input) == 0:
        return 0

    delimiter, input = _determinateDelimiter(input);

    input = _normalizeDelimiters(input, delimiter)

    numbers = [int(number) for number in input.split(delimiter)]

    numbers = _verifyNumberRanges(numbers)

    return sum(numbers)

