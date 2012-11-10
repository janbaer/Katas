describe("StringCalculator", function () {
    var calculator;

    beforeEach(function () {
        //calculator = new StringCalculator();
        calculator = stringCalculator;
    });

    describe("when the given string is empty", function () {
        it("should return 0", function () {
            var result = calculator.calc("");

            expect(result).toEqual(0);
        });
    });

    describe("when the given string contains one number", function () {
        it("should return this number", function () {
            var result = calculator.calc("1");

            expect(result).toEqual(1);
        });
    });

    describe("when the given string contains a list of numbers", function () {
        describe("and they are separated with a comma", function() {
            it("should return the sum of these numbers", function () {
                var result = calculator.calc("1,2");

                expect(result).toEqual(3);
            });
        });

        describe("and they are separated with a newline", function() {
            it("should return the sum of these numbers", function () {
                var result = calculator.calc("1\n2");

                expect(result).toEqual(3);
            });
        });
        describe("or they are separated with a komma or a newline", function() {
            it("should return the sum of these numbers", function () {
                var result = calculator.calc("1,2\n3");

                expect(result).toEqual(6);
            });
        });
   });

    describe("when the given string starts with a delimiter", function () {
        it("should use this delimiter", function() {
            var result = calculator.calc("//;\n1;2;3");
            expect(result).toEqual(6);
        });
    });

    describe("when a number is negative", function() {
        it("should throw an exception", function() {
            expect(function () {
                calculator.calc('-1,2,3');
            }).toThrow(new Error("Negative number found"));
        });
    });

});

