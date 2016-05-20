#pragma strict

var Terreno: Terrain;

var matrixAltura  : float[,];

var matrixTextura : float[,,];

var tamanhoMatriz: int;

var ResolucaoTextura: int;
var QntLayers: int;
var i: int;
var j: int;

var PontoX: float;
var PontoZ: float;

var Altura: float;

var Area: float;
var Area2: float;

var conta: float;

var MousePosicao:Ray;
var PontoMapa: RaycastHit;

function Start () {


    ResolucaoTextura = Terreno.terrainData.alphamapResolution;
    tamanhoMatriz    = Terreno.terrainData.heightmapResolution;
    QntLayers        = Terreno.terrainData.alphamapLayers;
    matrixAltura     = new float[tamanhoMatriz,tamanhoMatriz];

    matrixTextura    = new float[ResolucaoTextura,ResolucaoTextura,QntLayers];


    for (i=0; i<tamanhoMatriz;i++)
    {
        for (j=0; j<tamanhoMatriz;j++)
        {
            matrixAltura[i,j] = 0;
        }
    }


    for (i=0; i<ResolucaoTextura;i++)
    {
        for (j=0; j<ResolucaoTextura;j++)
        {
            matrixTextura[i,j,0] = 1;
            matrixTextura[i,j,1] = 0;
            matrixTextura[i,j,2] = 0;
        }
    }

    Terreno.terrainData.SetAlphamaps(0,0,matrixTextura);

    Terreno.terrainData.SetHeights(0,0,matrixAltura);

}

function Update () {

    if (Input.GetKeyDown(KeyCode.Space))
    {

        for (i=0; i<tamanhoMatriz;i++)
        {
            for (j=0; j<tamanhoMatriz;j++)
            {
                matrixAltura[i,j] = Random.Range(0,10.0/Terreno.terrainData.heightmapResolution);
            }
        }
        Terreno.terrainData.SetHeights(0,0,matrixAltura);
    }

    if (Input.GetKeyDown(KeyCode.Escape))
    {

        for (i=0; i<tamanhoMatriz;i++)
        {
            for (j=0; j<tamanhoMatriz;j++)
            {
                matrixAltura[i,j] = 0;
            }
        }
        Terreno.terrainData.SetHeights(0,0,matrixAltura);
    }


    if (Input.GetKeyDown("c"))
    {
        PontoX = Random.Range(0,Terreno.terrainData.heightmapResolution);
        PontoZ = Random.Range(0,Terreno.terrainData.heightmapResolution);
        Altura = Random.Range(10,30);

        Altura = Altura/Terreno.terrainData.heightmapResolution;

        Area = 50.0;
        for (i=PontoX-Area; i<PontoX+Area;i++)
        {
            for (j=PontoZ-Area; j<PontoZ+Area;j++)
            {
                matrixAltura[i,j] = Altura;
            }
        }
        Terreno.terrainData.SetHeights(0,0,matrixAltura);
    }

    if(Input.GetMouseButton(0))
    {
        MousePosicao = GetComponent.<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(MousePosicao,PontoMapa))
        {
            i = PontoMapa.point.x;
            j = PontoMapa.point.z;
            PontoX = PontoMapa.point.x - Terreno.transform.position.x;
            PontoZ = PontoMapa.point.z - Terreno.transform.position.z;
  
            PontoX = (PontoX*Terreno.terrainData.heightmapResolution)/Terreno.terrainData.size.x;
            PontoZ = (PontoZ*Terreno.terrainData.heightmapResolution)/Terreno.terrainData.size.z;
   
            Area = 50; 
            Altura = 10.0/Terreno.terrainData.heightmapResolution;
            for (i=PontoX-Area; i<PontoX+Area;i++)
            {
                for (j=PontoZ-Area; j<PontoZ+Area;j++)
                {
                    conta =  ((PontoX - i)*(PontoX - i))+((PontoZ - j)*(PontoZ - j));
                    Area2 = Area*Area;
                    if (conta<Area2)
                    {
                        // if (Altura - (Altura * (conta/Area2))> matrixAltura[j,i])
                        // {
                        matrixAltura[j,i] +=  Altura - (Altura * (conta/Area2));
                        // }
                    }
                }
            }
            Terreno.terrainData.SetHeights(0,0,matrixAltura);


            PontoX = PontoMapa.point.x - Terreno.transform.position.x;
            PontoZ = PontoMapa.point.z - Terreno.transform.position.z;
  
            PontoX = (PontoX*Terreno.terrainData.alphamapResolution)/Terreno.terrainData.size.x;
            PontoZ = (PontoZ*Terreno.terrainData.alphamapResolution)/Terreno.terrainData.size.z;
   
            Area = 55;
  
  
            // (PontoX - PontoXF)Â² + (PontoZ - PontoZF)Â² < 30Â²    
            for (i=PontoX-Area; i<PontoX+Area;i++)
            {
                for (j=PontoZ-Area; j<PontoZ+Area;j++)
                {
                    conta =  ((PontoX - i)*(PontoX - i))+((PontoZ - j)*(PontoZ - j));
                    Area2 = Area*Area;
                    if (conta<Area2)
                    {
                        matrixTextura[j,i,1] = 0;
                        if (matrixTextura[j,i,0]<1 * (conta/Area2))
                        {
                            matrixTextura[j,i,0] = 1 * (conta/Area2);
                        }
       
                        matrixTextura[j,i,2] = 1 - (1 * (conta/Area2));
       
                    }
                }
            }
            Terreno.terrainData.SetAlphamaps(0,0,matrixTextura);
        }
    }
}