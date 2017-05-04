---
uid: mayoFormat.md
title: Mayo Format and Querying
---

# Mayo Format and Querying DVH Metrics
The format of DVH queries supported in ESAPIX are defined in a [paper by Mayo et al.](https://www.ncbi.nlm.nih.gov/pubmed/26825250). Complex DVH queries can be consolidated into an abbreviated format which is described below.

## Format Overview
The Mayo format is broken down into the following components:
1. Query Type **Qt**
2. Query Value **Qv** (if necessary)
3. Query Units **Qu** (if necessary)
4. Units Desired **Ud**

They are ordered as :
```cs
QtQvQu[Ud]
```
### Query Type
The query type specifies the users interest in dose, volume, compliment dose, or compliment volume. The options are :
* MinDose - minimum dose of the structure
* MeanDose - average dose of the structure
* MaxDose - maximum dose of the structure
* D - Dose at volume (treated dose). The dose at 95% volume will report the maximum dose which covers 95 % of the volume.
* V - Volume at dose (treated volume). The volume of 70 Gy will report the volume which recieved 70 Gy or more.
* DC - Dose compliment at volume (cold spot of a structure). The dose compliment at 2% will give the maximum dose in the coldest 2 % of a structure.
* CV - Compliment volume (spared volume). The compliment volume of 20 Gy will report the volume which recieved 20 Gy or less.

### Query Value
The query value specifies the numerical point at which the query will take place. This is not required for mean, min, and max dose. If you were querying the dose in Gy to 90 percent of the volume, the query value would be 90. The written value would be
```cs
D90%[Gy]
```

### Query Units
Query units specifiy the units of the query value. This is not required for mean, min, and max dose. In the above example (D90%[Gy]), the unit is %. Supported units are :

Dose Units

* cGy
* Gy
* %

Volume Units

* %
* cc

### Units Desired
The units desired specifies the units in which you want the result returned. If you wanted the percent volume receiving 95 percent of prescribed dose, you would write :
```cs
V95%[%]
```
where the bracketed [%] specifies the desired return units. The bracket is also necessary.

## Examples
```cs
var ps = new PlanSetup(); //Assume we got a real one from a patient
var prostate = ps.StructureSet.Structures.First(s=>s.Id=="Prostate");
//Max dose in gray to prostate
var max = ps.ExecuteQuery(prostate, "MaxDose[Gy]");

//You can also query from multiple structures simultaneously (equivalent to a boolean OR of both structure volumes)
var leftParotid = ...
var rightParotid = ...
//Get the spared volume in cubic centimeters receiving less than 20 Gy from the combined parotid volumes
var spared = ps.ExecuteQuery(new Structure[]{leftParotid, rightParotid}, "CV20Gy[cc]");
```

