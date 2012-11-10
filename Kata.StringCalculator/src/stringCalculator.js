var stringCalculator = (function () {
	"use strict";

	function splitinputString(inputString, delimiters) {
		var numbers = inputString.split(delimiters[0]);

		for (var i = 1; i < delimiters.length; i++) {
			var temp = [];

			for (var j = 0; j < numbers.length; j++) {
				temp = temp.concat(numbers[j].split(delimiters[i]));		
			}

			numbers = temp;
		}

	    return numbers;
	}


	var regexp = /\/\/(.)\n(.+)/;
    
	function checkInputStringForDelimiterOrUseDefaultDelimiters(inputString){
    	var match = regexp.exec(inputString);
    	if (match != null) {
    	    return [match[1]];
		}

    	return [',', '\n'];
	}

	function removeOptionalLeadingDelimiter(inputString) {
		var match = regexp.exec(inputString);
		if (match != null) {
			return match[2];
		}

		return inputString;
	}

	function containsANegativeNumber(numbers) {
		for (var i = 0; i < numbers.length; i++) {
			if (parseInt(numbers[i]) < 0) {
				return true;
			}
		}

		return false;
	}


	return {
		calc: function(inputString) {
		    if (inputString.length == 0) {
		        return 0;
		    }

		    var delimiters = checkInputStringForDelimiterOrUseDefaultDelimiters(inputString);
		    inputString = removeOptionalLeadingDelimiter(inputString);
		    var numbers = splitinputString(inputString, delimiters);

		    if (containsANegativeNumber(numbers)) {
		    	throw("Negative number found");
		    }
		    
		    var sum = 0;
		    for (var i = 0; i < numbers.length; i++) {
		        sum += parseInt(numbers[i]);
		    }
		    return sum;	
		}
	};
})();


