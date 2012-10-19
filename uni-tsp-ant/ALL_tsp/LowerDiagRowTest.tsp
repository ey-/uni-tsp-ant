NAME: Test LOWER DIAG ROW
TYPE: TSP
COMMENT: Simuliert 5 Punkte; Herausvorderung: der letze Eintrag ist in der gleichen Zeile wie der vorletzte
DIMENSION: 5
EDGE_WEIGHT_TYPE: EXPLICIT
EDGE_WEIGHT_FORMAT: LOWER_DIAG_ROW 
DISPLAY_DATA_TYPE: TWOD_DISPLAY
EDGE_WEIGHT_SECTION
 0
 1	0
 2  3 0
 3 4 5 0
 4 5 6 7 0
DISPLAY_DATA_SECTION
1	0.0		4.0
2	1.0		3.0
3	2.0		2.0
4	3.0		1.0
5	4.0		0.0
EOF