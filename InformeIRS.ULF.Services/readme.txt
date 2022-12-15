CREATE OR REPLACE VIEW UNIMEDLF.VW_INFORME_IR AS
SELECT      ARQ.ANO_REFERENCIA                  AS ANO_REFERENCIA,
            ITE.COD_CONTRATO                    AS COD_CONTRATO,
            ITE.CPF_TITULAR                     AS CPF_TITULAR,
            'NOME TITULAR'                      AS NOME_TITULAR,
            ITE.DOCUMENTO                       AS DOCUMENTO_BENEFICIARIO,
            ITE.NOME                            AS NOME_BENEFICIARIO,
            INF_DEP.TDD_DESCRICAO               AS TIPO_DEPENDENCIA,
            ITE.DATA_NASCIMENTO                 AS DATA_NASCIMENTO_BENEFICIARIO,
            SYSDATE                             AS DATA_ATENDIMENTO,
            ITE.COD_BENEFICIARIO                AS CARTAO_BENEFICIARIO,
            ITE.COD_TITULAR                     AS CARTAO_TITULAR,
            CTRBENF.CBN_DATA_CONTRATACAO        AS DATA_CONTRATACAO,
            INFBENEF.BEN_DATA_INCLUSAO_CONTRATO AS DATA_INCLUSAO_BENEFICIARIO,
            DTR.ID_DMED_TIPO_REGISTRO           AS TIPO_REGISTO,
            DTR.DESCRICAO                       AS DESCRICAO_REGISTO,
            DTR.ORDEM                           AS ORDEM_REGISTO,
            SUM(DVI.VALOR)                      AS VALOR_TOTAL
       FROM UNIMEDLF.TB_DMED_ITENS_ARQUIVO ITE,
            UNIMEDLF.TB_DMED_VALORES_ITEM DVI,
            UNIMEDLF.TB_DMED_ARQUIVOS ARQ,
            unimedlf.tb_dmed_tipos_registro dtr,
            INF_BENEFICIARIOS INFBENEF,
            INF_TIPOS_DE_DEPENDENCIAS INF_DEP,
            INF_CONTRATOS_DE_BENEFICIARIO CTRBENF
      WHERE ARQ.ID_DMED_ARQUIVO                    = ITE.ID_DMED_ARQUIVO
        AND ITE.IND_ATIVO                          = 'S'
        AND INFBENEF.BEN_COD_BENEFICIARIO          = ITE.COD_BENEFICIARIO
        AND INF_DEP.TDD_CODIGO_TIPO_DEPENDENCIA    = ITE.COD_TIPO_DEPENDENCIA
        and DTR.ID_DMED_TIPO_REGISTRO              = ite.id_dmed_tipo_registro
        AND CTRBENF.CBN_COD_CONTRATO               = ITE.COD_CONTRATO
        AND DVI.ID_DMED_ITEM_ARQUIVO (+)           = ITE.ID_DMED_ITEM_ARQUIVO
        AND DVI.IND_ATIVO                          = 'S'
   GROUP BY ARQ.ANO_REFERENCIA,
            ITE.COD_CONTRATO,
            ITE.CPF_TITULAR,
            ITE.DATA_NASCIMENTO,
            ITE.DOCUMENTO,
            ITE.NOME,
            ITE.COD_BENEFICIARIO,
            ITE.COD_TITULAR,
            CTRBENF.CBN_DATA_CONTRATACAO,
            DTR.ID_DMED_TIPO_REGISTRO,
            DTR.DESCRICAO,
            DTR.ORDEM,
            INF_DEP.TDD_DESCRICAO,
            BEN_DATA_INCLUSAO_CONTRATO
ORDER BY DTR.ID_DMED_TIPO_REGISTRO;
