#!/usr/bin/bash

if [ $# -ne 2 ]; then
  echo "Usage: $0 <EntityNameSnake> <entityNameFirstLower>"
  echo "Example: $0 VolunteerProfile volunteerProfile"
  exit 1
fi

cd "$(dirname "$0")"

ENTITY_NAME_PROVIDED=$1
ENTITY_NAME_LOWER_START=$2

# classes 
DOMAIN_IMPL_DIR="../../Src/Common/Domain/implementation"
TARGET_PATH=${DOMAIN_IMPL_DIR}/${ENTITY_NAME_PROVIDED}.cs
if [ ! -f $TARGET_PATH ]; then
  cp tmpl/Entity.cs ${TARGET_PATH}
  sed -i "s/Entity/${ENTITY_NAME_PROVIDED}/g" ${TARGET_PATH}
  sed -i "s/entity/${ENTITY_NAME_LOWER_START}/g" ${TARGET_PATH}
  unix2dos ${TARGET_PATH}
  git add ${TARGET_PATH} 2> /dev/null
fi

DOMAIN_INT_DIR="../../Src/Common/Domain/interface"
TARGET_PATH=${DOMAIN_INT_DIR}/I${ENTITY_NAME_PROVIDED}.cs
if [ ! -f $TARGET_PATH ]; then
  cp tmpl/IEntity.cs ${TARGET_PATH}
  sed -i "s/Entity/${ENTITY_NAME_PROVIDED}/g" ${TARGET_PATH}
  sed -i "s/entity/${ENTITY_NAME_LOWER_START}/g" ${TARGET_PATH}
  unix2dos ${TARGET_PATH}
  git add ${TARGET_PATH} 2> /dev/null
fi

DOMAIN_NULL_DIR="../../Src/Common/Domain/service/null"
TARGET_PATH=${DOMAIN_NULL_DIR}/Null${ENTITY_NAME_PROVIDED}Service.cs
if [ ! -f $TARGET_PATH ]; then
  cp tmpl/NullEntityService.cs ${TARGET_PATH}
  sed -i "s/Entity/${ENTITY_NAME_PROVIDED}/g" ${TARGET_PATH}
  sed -i "s/entity/${ENTITY_NAME_LOWER_START}/g" ${TARGET_PATH}
  unix2dos ${TARGET_PATH}
  git add ${TARGET_PATH} 2> /dev/null
fi

HBM_DIR="../../Src/Service/Service/persistence/hbm"
TARGET_PATH=${HBM_DIR_DIR}/${ENTITY_NAME_LOWER_START}.hbm.xml
if [ ! -f $TARGET_PATH ]; then
  cp tmpl/entity.hbm.xml ${TARGET_PATH}
  sed -i "s/Entity/${ENTITY_NAME_PROVIDED}/g" ${TARGET_PATH}
  sed -i "s/entity/${ENTITY_NAME_LOWER_START}/g" ${TARGET_PATH}
  unix2dos ${TARGET_PATH}
  git add ${TARGET_PATH} 2> /dev/null
fi

SERVICE_DIR="../../Src/Service/service"
TARGET_PATH=${SERVICE_DIR}/${ENTITY_NAME_PROVIDED}Service.cs
if [ ! -f $TARGET_PATH ]; then
  cp tmpl/EntityService.cs ${TARGET_PATH}
  sed -i "s/Entity/${ENTITY_NAME_PROVIDED}/g" ${TARGET_PATH}
  sed -i "s/entity/${ENTITY_NAME_LOWER_START}/g" ${TARGET_PATH}
  unix2dos ${TARGET_PATH}
  git add ${TARGET_PATH} 2> /dev/null
fi

# tests
DOMAIN_TEST_DIR="../../Test/Common/DomainTest/implementation"
TARGET_PATH=${DOMAIN_TEST_DIR}/${ENTITY_NAME_PROVIDED}Test.cs
if [ ! -f $TARGET_PATH ]; then
  cp tmpl/EntityTest.cs ${TARGET_PATH}
  sed -i "s/Entity/${ENTITY_NAME_PROVIDED}/g" ${TARGET_PATH}
  sed -i "s/entity/${ENTITY_NAME_LOWER_START}/g" ${TARGET_PATH}
  unix2dos ${TARGET_PATH}
  git add ${TARGET_PATH} 2> /dev/null
fi

SERVICE_TEST_DIR="../../Test/Service/ServiceTest/service"
TARGET_PATH=${SERVICE_TEST_DIR}/${ENTITY_NAME_PROVIDED}ServiceTest.cs
if [ ! -f $TARGET_PATH ]; then
  cp tmpl/EntityServiceTest.cs ${TARGET_PATH}
  sed -i "s/Entity/${ENTITY_NAME_PROVIDED}/g" ${TARGET_PATH}
  sed -i "s/entity/${ENTITY_NAME_LOWER_START}/g" ${TARGET_PATH}
  unix2dos ${TARGET_PATH}
  git add ${TARGET_PATH} 2> /dev/null
fi

