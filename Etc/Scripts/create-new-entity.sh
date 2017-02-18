#!/usr/bin/bash

if [ $# -ne 2 ]; then
  echo "Usage: $0 <EntityNameSnake> <entityNameFirstLower>"
  echo "Example: $0 VolunteerProfile volunteerProfile"
  exit 1
fi

cd "$(dirname "$0")"

ENTITY_NAME_PROVIDED=$1
ENTITY_NAME_LOWER_START=${2}

# classes 
DOMAIN_IMPL_DIR="../../Src/Common/Domain/implementation"
cp tmpl/Entity.cs ${DOMAIN_IMPL_DIR}/${ENTITY_NAME_PROVIDED}.cs
sed -i "s/Entity/${ENTITY_NAME_PROVIDED}/g" ${DOMAIN_IMPL_DIR}/${ENTITY_NAME_PROVIDED}.cs
sed -i "s/entity/${ENTITY_NAME_LOWER_START}/g" ${DOMAIN_IMPL_DIR}/${ENTITY_NAME_PROVIDED}.cs
unix2dos ${DOMAIN_IMPL_DIR}/${ENTITY_NAME_PROVIDED}.cs
git add ${DOMAIN_IMPL_DIR}/${ENTITY_NAME_PROVIDED}.cs 2> /dev/null

DOMAIN_INT_DIR="../../Src/Common/Domain/interface"
cp tmpl/IEntity.cs ${DOMAIN_INT_DIR}/I${ENTITY_NAME_PROVIDED}.cs
sed -i "s/Entity/${ENTITY_NAME_PROVIDED}/g" ${DOMAIN_INT_DIR}/I${ENTITY_NAME_PROVIDED}.cs
sed -i "s/entity/${ENTITY_NAME_LOWER_START}/g" ${DOMAIN_INT_DIR}/I${ENTITY_NAME_PROVIDED}.cs
unix2dos ${DOMAIN_INT_DIR}/I${ENTITY_NAME_PROVIDED}.cs
git add ${DOMAIN_INT_DIR}/I${ENTITY_NAME_PROVIDED}.cs 2> /dev/null

DOMAIN_NULL_DIR="../../Src/Common/Domain/service/null"
cp tmpl/NullEntityService.cs ${DOMAIN_NULL_DIR}/Null${ENTITY_NAME_PROVIDED}Service.cs
sed -i "s/Entity/${ENTITY_NAME_PROVIDED}/g" ${DOMAIN_NULL_DIR}/Null${ENTITY_NAME_PROVIDED}Service.cs
sed -i "s/entity/${ENTITY_NAME_LOWER_START}/g" ${DOMAIN_NULL_DIR}/Null${ENTITY_NAME_PROVIDED}Service.cs
unix2dos ${DOMAIN_NULL_DIR}/Null${ENTITY_NAME_PROVIDED}Service.cs
git add ${DOMAIN_NULL_DIR}/Null${ENTITY_NAME_PROVIDED}Service.cs 2> /dev/null

HBM_DIR="../../Src/Service/Service/persistence/hbm"
cp tmpl/Entity.hbm.xml ${HBM_DIR_DIR}/${ENTITY_NAME_LOWER_START}.hbm.xml
sed -i "s/Entity/${ENTITY_NAME_PROVIDED}/g" ${HBM_DIR_DIR}/${ENTITY_NAME_LOWER_START}.hbm.xml
sed -i "s/entity/${ENTITY_NAME_LOWER_START}/g" ${HBM_DIR_DIR}/${ENTITY_NAME_LOWER_START}.hbm.xml
unix2dos ${HBM_DIR}/${ENTITY_NAME_LOWER_START}.hbm.xml
git add ${HBM_DIR}/${ENTITY_NAME_LOWER_START}.hbm.xml 2> /dev/null

SERVICE_DIR="../../Src/Service/service"
cp tmpl/EntityService.cs ${SERVICE_DIR}/${ENTITY_NAME_PROVIDED}Service.cs
sed -i "s/Entity/${ENTITY_NAME_PROVIDED}/g" ${SERVICE_DIR}/${ENTITY_NAME_PROVIDED}Service.cs
sed -i "s/entity/${ENTITY_NAME_LOWER_START}/g" ${SERVICE_DIR}/${ENTITY_NAME_PROVIDED}Service.cs
unix2dos ${SERVICE_DIR}/${ENTITY_NAME_PROVIDED}Service.cs
git add ${SERVICE_DIR}/${ENTITY_NAME_PROVIDED}Service.cs 2> /dev/null

# tests
DOMAIN_TEST_DIR="../../Test/Common/DomainTest/implementation"
cp tmpl/EntityTest.cs ${DOMAIN_TEST_DIR}/${ENTITY_NAME_PROVIDED}Test.cs
sed -i "s/Entity/${ENTITY_NAME_PROVIDED}/g" ${DOMAIN_TEST_DIR}/${ENTITY_NAME_PROVIDED}Test.cs
sed -i "s/entity/${ENTITY_NAME_LOWER_START}/g" ${DOMAIN_TEST_DIR}/${ENTITY_NAME_PROVIDED}Test.cs
unix2dos ${DOMAIN_TEST_DIR}/${ENTITY_NAME_PROVIDED}Test.cs
git add ${DOMAIN_TEST_DIR}/${ENTITY_NAME_PROVIDED}Test.cs 2> /dev/null

SERVICE_TEST_DIR="../../Test/Service/ServiceTest/service"
cp tmpl/EntityServiceTest.cs ${SERVICE_TEST_DIR}/${ENTITY_NAME_PROVIDED}ServiceTest.cs
sed -i "s/Entity/${ENTITY_NAME_PROVIDED}/g" ${SERVICE_TEST_DIR}/${ENTITY_NAME_PROVIDED}ServiceTest.cs
sed -i "s/entity/${ENTITY_NAME_LOWER_START}/g" ${SERVICE_TEST_DIR}/${ENTITY_NAME_PROVIDED}ServiceTest.cs
unix2dos ${SERVICE_TEST_DIR}/${ENTITY_NAME_PROVIDED}ServiceTest.cs
git add ${SERVICE_TEST_DIR}/${ENTITY_NAME_PROVIDED}ServiceTest.cs 2> /dev/null

