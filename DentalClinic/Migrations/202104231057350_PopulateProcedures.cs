namespace DentalClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProcedures : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"INSERT INTO [Procedure] (Name,Duration,Speciality,Price)
                values ('Consultație',30,0,100),
                ('Obturație fizionomică cu material compozit ',30,0,250),
                ('Coafaj (pansament)',30,0,150),
                ('Extracție simplă monoradiculară',30,0,200),

                ('Consultație ortodontică',60,1,100),
                ('Realizarea și analiza modelului de studiu + plan de tratament',30,1,100),
                ('Aparat mobil / arcadă',120,1,1000),
                ('Aparat ortodontic cu bracket-uri metalice / arcadă',120,1,2500),
                ('Aparat ortodontic cu bracket-uri metalice cu profil redus / arcadă',120,1,2500),
                ('Aparat ortodontic cu bracket-uri safir / arcadă',120,1,3500),
                ('Clear Aligner / gutieră pentru aliniere',120,1,6000),

                ('Consultație',30,2,150),
                ('Măsurători parodontale',30,2,200),
                ('Chiuretaj subgingival în câmp închis',60,2,1000),
                ('Chiuretaj subgingival în câmp închis pe arcadă',120,2,1000),
                ('Chiuretaj subgingival în câmp deschis 1 dinte',30,2,250),
                ('Lambou de repoziționare și grefă gingivală',30,2,700),
                ('Lambou de repoziționare (tratament pentru retracții gingivale) 1-3 dinți',60,2,500),

                ('Coroană metalo-ceramică',60,3,700),
                ('Coroană integral ceramică',60,3,1300),
                ('Coroană ceramică pe suport de zirconiu',60,3,1300),
                ('Coroană de zirconiu monolit',60,3,1300),
                ('Coroană provizorie realizată în cabinet',30,3,150),
                ('Coroană provizorie din PMMA realizată în laboratorul dentar',30,3,250),
                ('Fațetă ceramică',30,3,1300),
                ('Wax-up și Mock-up',30,3,100),
                ('Onlay / inlay ceramic',30,3,1000),
                ('Onlay / inlay compozit',30,3,1000),

                ('Consultație de specialitate',30,4,150),
                ('Tratament endodontic dinți frontali',60,4,600),
                ('Tratament endodontic premolari',60,4,700),
                ('Tratament endodontic molari',60,4,850),
                ('Tratament endodontic molari cu anatomie complexă',60,4,950),
                ('Retratament endodontic dinți frontali',60,4,660),
                ('Retratament endodontic premolari',60,4,800),
                ('Retratament endodontic molari',60,4,1000),
                ('Retratament endodontic molari cu anatomie complexă',60,4,1200),

                ('Extracție',30,5,270),
                ('Extracție cu socket preservation (adiție osoasă)',60,5,350),
                ('Extracție + conuri de collagen',60,5,380),
                ('Extracție molar de minte',60,5,400),
                ('Odontectomie molar de minte superior',60,5,400),
                ('Odontectomie molar de minte inferior',60,5,500),
                ('Rezecție apicală',60,5,500),
                ('Implant dentar',120,5,4500),
                ('Coroană metalo-ceramică pe implant dentar (cimentată / înșurubată)',120,5,1500),
                ('Coroană ceramică Zirconiu pe implant dentar',120,5,4500),

                ('Extracție',30,6,350),
                ('Sinus lift',120,6,4500),
                ('Adiție osoasă',120,6,4500),
                ('Premolarizare',120,6,250)"
            );
        }
        
        public override void Down()
        {
        }
    }
}
