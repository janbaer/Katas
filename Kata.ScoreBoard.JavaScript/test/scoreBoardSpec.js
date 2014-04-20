/* globals Team, Match, Group, ScoreBoard */

'use strict';

describe('Group spec', function () {
  var group = new Group();

  beforeEach(function () {
    group.teams.push(new Team('Germany'));
    group.teams.push(new Team('France'));
  });
  describe('When Group.teamByName was called', function () {
    it('Should return the expected team', function () {
      expect(group.teamByName('France').name).toEqual('France');
    });
  });
});

describe('ScoreBoard spec', function () {
    var scoreboard, team1, team2, team3, game1, game2;

    beforeEach(function () {
      scoreboard = new ScoreBoard();
    });

    describe('When 8 teams was added', function () {
      beforeEach(function () {
        scoreboard.buildGroups('Germany', 'France', 'Spain', 'Brazil', 'Argentina', 'USA', 'Russia', 'Holland');
      });

      it('Should should have 2 groups with 4 teams in each group', function () {
        expect(scoreboard.groups.length).toBe(2);
        expect(scoreboard.groups[0].teams.length).toBe(4);
      });

      describe('When the first game was played', function () {
        describe('and the the first team has more goals than the secon team', function () {
          var team1, team2;

          beforeEach(function () {
            team1 = scoreboard.groups[0].teams[0];
            team2 = scoreboard.groups[0].teams[1];
            scoreboard.playMatch(team1, team2, 2, 1);
          });

          it('Should give the winning team three points and the loosing team zero points', function () {
            expect(team1.points).toBe(3);
            expect(team2.points).toBe(0);
          });

          it('Should give team1 two goalsfor and one goals against', function () {
            expect(team1.goalsFor).toBe(2);
            expect(team1.goalsAgainst).toBe(1);
          });

          it('Should give team2 one goalsfor and two goals against', function () {
            expect(team2.goalsFor).toBe(1);
            expect(team2.goalsAgainst).toBe(2);
          });

          it('Should calculate the goaldifference for each team', function () {
            expect(team1.goalDifference).toBe(1);
            expect(team2.goalDifference).toBe(-1);
          });
        });
      });

      describe('When each team in a group has different points', function () {
        var group1;

        beforeEach(function () {
          group1 = scoreboard.groups[0];

          group1.teamByName('Germany').points = 3;
          group1.teamByName('France').points = 4;
          group1.teamByName('Brazil').points = 1;
          group1.teamByName('Spain').points = 2;

          scoreboard.sortGroups();
        });

        it('Should order the group by the team with most points', function () {
          expect(group1.teams[0].name).toBe('France');
          expect(group1.teams[1].name).toBe('Germany');
          expect(group1.teams[2].name).toBe('Spain');
          expect(group1.teams[3].name).toBe('Brazil');
        });
      });

      describe('When 2 teams has equal points but 1 team has a better goal difference', function () {
        var group1;

        beforeEach(function () {
          group1 = scoreboard.groups[0];

          group1.teamByName('Germany').points = 1;
          group1.teamByName('France').points = 2;
          group1.teamByName('Brazil').points = 2;
          group1.teamByName('Spain').points = 4;

          group1.teamByName('France').goalDifference = 3;
          group1.teamByName('Brazil').goalDifference = 2;

          scoreboard.sortGroups();
        });

        it('Should order the teams by the goal difference', function () {
          expect(group1.teams[0].name).toBe('Spain');
          expect(group1.teams[1].name).toBe('France');
          expect(group1.teams[2].name).toBe('Brazil');
          expect(group1.teams[3].name).toBe('Germany');
        });
      });

      describe('When 2 teams has equal points and equal goal difference', function () {
        var group1;

        beforeEach(function () {
          group1 = scoreboard.groups[0];

          group1.teamByName('Germany').points = 1;
          group1.teamByName('France').points = 2;
          group1.teamByName('Brazil').points = 0;
          group1.teamByName('Spain').points = 4;

          group1.teamByName('France').goalDifference = 3;
          group1.teamByName('Brazil').goalDifference = 1;

          scoreboard.playMatch(group1.teamByName('Brazil'), group1.teamByName('France'), 2, 1);

          scoreboard.sortGroups();
        });

        it('Should give the winner of the match between this teams the bether position', function () {
          expect(group1.teams[0].name).toBe('Spain');
          expect(group1.teams[1].name).toBe('Brazil');
          expect(group1.teams[2].name).toBe('France');
          expect(group1.teams[3].name).toBe('Germany');
        });
      });

    });


});
