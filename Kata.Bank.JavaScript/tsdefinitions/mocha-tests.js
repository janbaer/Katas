function test_describe() {
    describe('something', function () {
    });

    describe.only('something', function () {
    });

    describe.skip('something', function () {
    });

    describe('something', function () {
        this.timeout(2000);
    });
}

function test_it() {
    it('does something', function () {
    });

    it('does something', function (done) {
        done();
    });

    it.only('does something', function () {
    });

    it.skip('does something', function () {
    });

    it('does something', function () {
        this.timeout(2000);
    });
}

function test_before() {
    before(function () {
    });

    before(function (done) {
        done();
    });
}

function test_after() {
    after(function () {
    });

    after(function (done) {
        done();
    });
}

function test_beforeEach() {
    beforeEach(function () {
    });

    beforeEach(function (done) {
        done();
    });
}

function test_afterEach() {
    afterEach(function () {
    });

    afterEach(function (done) {
        done();
    });
}
//@ sourceMappingURL=mocha-tests.js.map
