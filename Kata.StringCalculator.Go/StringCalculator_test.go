package StringCalcularTests

import (
	"github.com/stretchr/testify/assert"
	"strconv"
	"strings"
	"testing"
)

func parse(input string) int {
	if input == "" {
		return 0
	}

	sum := 0

	numbers := strings.Split(input, "")
	for _, number := range numbers {
		val, _ := strconv.Atoi(number)
		sum += val
	}

	return sum
}

func TestWhenStringIsEmptyIsShouldReturn0(t *testing.T) {
	assert.Equal(t, parse(""), 0)
}

func TestWhenStringContainsANumberItShouldReturnTheNumericValue(t *testing.T) {
	assert.Equal(t, parse("1"), 1)
}

func TestWhenStringContainsTwoNumbersItShouldReturnTheSumOfIt(t *testing.T) {
	assert.Equal(t, parse("2,3"), 5)
}

func TestWhenStringContainsMoreThanTwoNumbersItShouldReturnTheSumOfAll(t *testing.T) {
	assert.Equal(t, parse("2,3,4"), 9)
}
