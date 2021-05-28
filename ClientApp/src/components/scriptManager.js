/* eslint-disable */
import _ from 'underscore'

var scriptManager = {

  getMinimumEdgeCoverSets(edgesArray) {
    // console.log(edgesArray);

    var multiplicated = edgesArray[0];
    //multiplicated.push();
    //console.log(multiplicated);
    //console.log(edgesArray);

    var i = 0;
    var j = 0;
    var k = 0;

    // wziêcie kolejnego setu krawêdzi (ca³y nawias)
    for (i = 1; i < edgesArray.length; i++) {


      var temp2 = [];
      // wziêcie kolejnej krawêdzi z nawiasu.  j = 1, bo pierwszy nawias ju¿ jest w zmiennej "multiplicated.push(edgesArray[0])"
      for (j = 0; j < edgesArray[i].length; j++) {

        // "pomno¿enie" tej krawêdzi przez ka¿dy element ze zmiennej multiplicated
        for (k = 0; k < multiplicated.length; k++) {

          //console.log("mult length: " + multiplicated[0]);
          //console.log(edgesArray[i][j]);
          //console.log(multiplicated[k]);

          var temp = '';

          // for do wyszukiwania czy dok³adnie dana wartoœæ wystêpujê w multiplicated (¿eby nie by³o 6,6 np)
          var startIndex = 0;
          var flag = false;
          while (true) {

            var index = multiplicated[k].indexOf(edgesArray[i][j], startIndex);
            //console.log("index: " + index);
            if (index != -1) {
              startIndex = index+1;
              //console.log("edgesArray[i][j]: " + edgesArray[i][j]);
              //console.log("multiplicated[k]: " + multiplicated[k]);
              ///console.log("multiplicated[k][index-1]: " + multiplicated[k][index - 1]);
              ///console.log("multiplicated[k][index + edgesArray[i][j].length]: " + multiplicated[k][index + edgesArray[i][j].length]);
              if ((multiplicated[k][index - 1] == ',' || typeof(multiplicated[k][index - 1]) === 'undefined')
                && (multiplicated[k][index + edgesArray[i][j].length] == ',' || typeof(multiplicated[k][index + edgesArray[i][j].length]) === 'undefined')) { // jak przed i po znakiem s¹ przecinki, to nie dodawaj
                flag = true;
              }
            } else {
              if (flag) {
                temp = multiplicated[k] + "";
              }
              else {
                temp = edgesArray[i][j] + "," + multiplicated[k];
              }
              break;
            }
          }
          //console.log("temp: " + temp);
          /*
          if (!multiplicated[k].includes(edgesArray[i][j])) {
            temp = edgesArray[i][j] + "," + multiplicated[k];
          }
          else {
            temp = multiplicated[k];
          }
          */
          //console.log(temp);
          //console.log("END*********************************************");
          temp2.push(temp);
        }

        //console.log(temp2);
        //console.log(multiplicated);
        //console.log("END K LOOP")
      }
      //console.log(temp2);

      // usuwa duplikaty i niepotrzebne elementy po ka¿dym wymno¿eniu nawiasów
      multiplicated = removeRepeatedString(temp2);
      //multiplicated = temp2;
      //console.log("ENDOOOOOOOOOOOOOOOOOOOOOOO");
    }
    //console.log(multiplicated.sort((a, b) => a.length - b.length))

    var result = removeRepeated(multiplicated);
    //console.log(result)
    return result;
  }
};

function removeRepeated(multiplicated) {
  //console.log(multiplicated.sort((a, b) => a.length - b.length));

  var i = 0;
  var j = 0;
  for (i = 0; i < multiplicated.length; i++) {

    multiplicated[i] = multiplicated[i].split(',');
    for (j = 0; j < multiplicated[i].length; j++) {
      multiplicated[i][j] = parseInt(multiplicated[i][j]);
    }
    multiplicated[i] = multiplicated[i].sort((a, b) => a - b);
  }
  //console.log(multiplicated);

  return multiplicated;
}


// usuwa powtórzenia oraz elementy, w których mog¹ zawieraæ siê inne elementy (np 1,2,3 zawiera siê w 1,2,3,5 -> usuniêcie 1,2,3,5)
function removeRepeatedString(tempMultiplicated) {
  //console.log(multiplicated.sort((a, b) => a.length - b.length));

  var i = 0;
  var j = 0;
  for (i = 0; i < tempMultiplicated.length; i++) {

    tempMultiplicated[i] = tempMultiplicated[i].split(',');
    for (j = 0; j < tempMultiplicated[i].length; j++) {
      tempMultiplicated[i][j] = parseInt(tempMultiplicated[i][j]);
    }
    tempMultiplicated[i] = tempMultiplicated[i].sort((a, b) => a - b);
  }

  var uniques = [];
  var itemsFound = {};
  for (var i = 0, l = tempMultiplicated.length; i < l; i++) {
    var stringified = JSON.stringify(tempMultiplicated[i]);
    if (itemsFound[stringified]) { continue; }
    uniques.push(tempMultiplicated[i]);
    itemsFound[stringified] = true;
  }
  uniques = uniques.sort((a, b) => a.length - b.length);
  //console.log(uniques);

  // biorê jedno wyra¿enie
  for (i = 0; i < uniques.length; i++) {

    // porównuje z reszt¹ czy nie zawiera siê w innych
    for (j = 0; j < uniques.length; j++) {
      if ((_.difference(uniques[i], uniques[j]).length === 0) && uniques[j] != uniques[i]) {
        uniques[j] = "XXXXX";
      }

    }
  }

  // usuñ wszystkie XXXXX
  for (var p = uniques.length; p--;) {
    if (uniques[p] === 'XXXXX') uniques.splice(p, 1);
  }
  //console.log(uniques);

  // zapisz uniques jako array stringów, ¿eby mo¿na by³o dalej wykonywaæ na nich operacje w getMinimumEdgeCoverSets()


  var uniquesStrings = [];
  for (var h = 0; h < uniques.length; h++)
  {
    uniquesStrings[h] = uniques[h].join(',');
  }
  //console.log(uniquesStrings);

  return uniquesStrings;

}

export default scriptManager
