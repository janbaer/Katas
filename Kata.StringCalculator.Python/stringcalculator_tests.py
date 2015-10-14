from nose.tools import * # This is necessary for @raises
from nose.tools import set_trace

from stringcalculator import add

def test_when_string_is_empty_it_should_return_0():
    assert add("") == 0

def test_when_string_contains_a_number_it_should_return_the_value():
    assert add("1") == 1

def test_when_string_contains_a_sepator_it_should_return_the_sum_of_all_numbers():
    assert add("1,2") == 3

def test_when_string_contains_newLine_it_should_accept_it_as_delimiter():
    assert add("1\n2,3") == 6

def test_when_string_starts_with_the_definition_of_the_delimiter_it_should_use_this():
    assert add("//;\n1;2;3") == 6

def test_when_a_number_is_greater_1000_it_should_ignore_it():
    assert add("1,1001,2") == 3

@raises(ValueError)
def test_when_a_number_is_negative_it_should_raise_an_error():
    add("-1,2")
