'use strict';

var Team = function (name) {
  this.name = name;
  this.points = 0;
  this.goalsFor = 0;
  this.goalsAgainst = 0;
  this.goalDifference = 0;
  this.matches = [];
};

Team.prototype.toString = function () {
  return this.name;
};

var Match = function (team1, team2, goalsForTeam1, goalsForTeam2) {
  this.team1 = team1;
  this.team2 = team2;
  this.goalsForTeam1 = goalsForTeam1;
  this.goalsForTeam2 = goalsForTeam2;

  var getWinner = function () {
    if (this.goalsForTeam1 > this.goalsForTeam2) {
      return this.team1;
    } else if (this.goalsForTeam1 < this.goalsForTeam2) {
      return this.team2;
    }

    return null;
  };
};

var Group = function () {
  this.teams = [];

  this.teamByName = function (name) {
    var foundTeams = this.teams.filter(function (team) {
      return team.name === name;
    });
    return foundTeams.length > 0 ? foundTeams[0] : null;
  };
};

var ScoreBoard = function () {
  this.groups = [];

  var addGoals = function (team, goalsFor, goalsAgainst) {
    team.goalsFor += goalsFor;
    team.goalsAgainst += goalsAgainst;
  };

  var givePoints = function (team, goalsFor, goalsAgainst) {
    if (goalsFor === goalsAgainst) {
      team.points += 1;
    } else if (goalsFor > goalsAgainst) {
      team.points += 3;
    } else {
      team.points += 0;
    }
  };

  var calculateGoalDifference = function (team) {
    team.goalDifference = team.goalsFor - team.goalsAgainst;
  };

  var addMatch = function (match) {
    match.team1.matches.push(match);
    match.team2.matches.push(match);
  };

  this.buildGroups = function () {
    var teamNames = [].slice.call(arguments);
    var group = new Group();

    for (var i = 0; i < teamNames.length; i++) {
      group.teams.push(new Team(teamNames[i]));
      if (group.teams.length === 4) {
        this.groups.push(group);
        group = new Group();
      }
    }
  };

  this.playMatch = function (team1, team2, goalsForTeam1, goalsForTeam2) {
    givePoints(team1, goalsForTeam1, goalsForTeam2);
    givePoints(team2, goalsForTeam2, goalsForTeam1);

    addGoals(team1, goalsForTeam1, goalsForTeam2);
    addGoals(team2, goalsForTeam2, goalsForTeam1);

    calculateGoalDifference(team1);
    calculateGoalDifference(team2);

    addMatch(new Match(team1, team2, goalsForTeam1, goalsForTeam2));
  };

  var compareTeamsByPoints = function (team1, team2) {
    if (team1.points > team2.points) {
      return -1;
    } else if (team1.points < team2.points) {
      return 1;
    }
    return 0;
  };

  var compareTeamsByGoalDifference = function (team1, team2) {
    if (team1.goalDifference > team2.goalDifference) {
      return -1;
    } else if (team1.goalDifference < team2.goalDifference) {
      return 1;
    }
    return 0;
  };

  var compareTeamsByWinningMatch = function (team1, team2) {
    var matchesBetweenTeams = team1.matches.filter(function (match) {
      if (match.team1 === team2 || match.team2 === team2) {
        return match;
      }
    });

    if (matchesBetweenTeams.length > 0) {
      var winner = matchesBetweenTeams[0].getWinner();
      if (winner === team1) {
        return -1;
      } else if (winner === team2) {
        return 1;
      }
    }
  };

  var compareTeams = function (team1, team2) {
    var result = compareTeamsByPoints(team1, team2);
    if (result === 0) {
      result = compareTeamsByGoalDifference(team1, team2);
    }
    if (result === 0) {
      result = compareTeamsByWinningMatch(team1, team2);
    }
    return result;
  };

  this.sortGroups = function () {
    this.groups.forEach(function (group) {
      group.teams.sort(compareTeams);
    });
  };
};

