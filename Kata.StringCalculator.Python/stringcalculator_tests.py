import unittest

from stringcalculator import Calculator

class StringCalculatorTests(unittest.TestCase):
  def when_string_is_empty_it_should_return_0_test(self):
      assert Calculator.calc("") == 0

  def when_string_contains_a_single_number_it_should_return_the_numeric_value_test(self):
      assert Calculator.calc("1") == 1

  def when_string_contains_two_numbers_it_should_return_the_sum_of_it_test(self):
      assert Calculator.calc("1,2") == 3

  def when_string_contains_different_separator_it_should_also_return_the_sum_of_it_test(self):
      assert Calculator.calc("1\n2,3") == 6

  def when_string_contains_another_separator_it_should_use_this_separator_test(self):
      assert Calculator.calc("1;2;3") == 6

  def when_a_number_is_negative_it_should_throw_an_error_test(self):
    self.assertRaises(ValueError, Calculator.calc, "1,-2,3")

  def when_a_number_is_greater_than_1000_it_should_ignore_this_number_test(self):
    assert Calculator.calc("1,1001,2") == 3
